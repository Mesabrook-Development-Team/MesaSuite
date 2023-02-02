using ClussPro.Base.Data.Query;
using ClussPro.Base.Extensions;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Utility;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClussPro.ObjectBasedFramework.Validation
{
    public static class Validator
    {
        private static Dictionary<SchemaObject, List<IValidationDefinition>> validationDefinitionsBySchemaObject;
        public static bool Validate(DataObject dataObject, SaveModes saveMode, List<Guid> saveFlags = null, ITransaction transaction = null)
        {
            if (validationDefinitionsBySchemaObject == null)
            {
                InitializeRules();
            }

            SchemaObject thisSchemaObject = Schema.Schema.GetSchemaObject(dataObject.GetType());
            List<IValidationDefinition> validationDefinitionsForObject = validationDefinitionsBySchemaObject.GetOrDefault(thisSchemaObject);
            if (validationDefinitionsForObject == null)
            {
                return true;
            }

            Func<ValidationRule, bool> validRulesDelegate = vr => saveFlags == null ? true : !saveFlags.Contains(vr.ID);

            DataObject objectToValidate = dataObject;
            IEnumerable<string> extraFields = validationDefinitionsForObject.SelectMany(def => def.ValidationRules.Where(validRulesDelegate).SelectMany(vr => vr.Condition.AdditionalDataObjectFields));
            if (extraFields.Any())
            {
                objectToValidate = DataObject.GetEditableByPrimaryKey(dataObject.GetType(), ConvertUtility.GetNullableLong(objectToValidate.PrimaryKeyField.GetValue(objectToValidate)), null, extraFields);
                if (objectToValidate == null)
                {
                    foreach(IGrouping<string, string> extraFieldsByPrefix in extraFields.GroupBy(field => field.Contains(".") ? field.Substring(0, field.IndexOf(".")) : string.Empty))
                    {
                        if (string.IsNullOrEmpty(extraFieldsByPrefix.Key))
                        {
                            continue;
                        }

                        Relationship relationship = thisSchemaObject.GetRelationship(extraFieldsByPrefix.Key);

                        if (relationship != null)
                        {
                            long? foreignKey = ConvertUtility.GetNullableLong(relationship.ForeignKeyField.GetValue(dataObject));
                            if (foreignKey == null)
                            {
                                continue;
                            }

                            IEnumerable<string> fieldsToRetrieve = extraFieldsByPrefix.Select(f => f.Substring(f.IndexOf(".") + 1));

                            DataObject relatedDataObject = DataObject.GetReadOnlyByPrimaryKey(relationship.RelatedObjectType, foreignKey, transaction, fieldsToRetrieve);
                            relationship.SetPrivateDataCallback(dataObject, relatedDataObject);
                        }
                    }

                    objectToValidate = dataObject;
                }
                else
                {
                    dataObject.Copy(objectToValidate);
                }
            }

            bool success = true;
            foreach(ValidationRule validationRule in validationDefinitionsForObject.SelectMany(vd => vd.ValidationRules.Where(validRulesDelegate).Where(vr =>
                                                                                                {
                                                                                                    switch(saveMode)
                                                                                                    {
                                                                                                        case SaveModes.Delete:
                                                                                                            return vr.ApplyOnDelete;
                                                                                                        case SaveModes.Insert:
                                                                                                            return vr.ApplyOnInsert;
                                                                                                        case SaveModes.Update:
                                                                                                            return vr.ApplyOnUpdate;
                                                                                                    }

                                                                                                    return false;
                                                                                                })))
            {
                bool result = validationRule.Condition.Evaluate(objectToValidate);
                if (!result)
                {
                    dataObject.Errors.Add(validationRule.Field, validationRule.Message);
                }

                success = result && success;
            }

            return success;
        }

        public enum SaveModes
        {
            Insert,
            Update,
            Delete
        }

        private static void InitializeRules()
        {
            validationDefinitionsBySchemaObject = new Dictionary<SchemaObject, List<IValidationDefinition>>();

            Type validationDefinitionType = typeof(IValidationDefinition);
            Type objectAttributeDefType = typeof(ObjectAttributeValidationDefinition);
            foreach(Type type in AppDomain
                                    .CurrentDomain
                                    .GetAssemblies()
                                    .SelectMany(assembly => 
                                        assembly
                                        .GetTypes()
                                        .Where(t => 
                                            validationDefinitionType.IsAssignableFrom(t) && t != validationDefinitionType && t != objectAttributeDefType)))
            {
                IValidationDefinition validationDefinition = (IValidationDefinition)Activator.CreateInstance(type);
                SchemaObject schemaObject = Schema.Schema.GetSchemaObject(validationDefinition.Schema, validationDefinition.Object);
                if (!validationDefinitionsBySchemaObject.ContainsKey(schemaObject))
                {
                    validationDefinitionsBySchemaObject.Add(schemaObject, new List<IValidationDefinition>());
                }

                validationDefinitionsBySchemaObject[schemaObject].Add(validationDefinition);
            }

            foreach(SchemaObject schemaObject in Schema.Schema.GetAllSchemaObjects())
            {
                ObjectAttributeValidationDefinition attributeDefinition = new ObjectAttributeValidationDefinition();
                attributeDefinition.Schema = schemaObject.SchemaName;
                attributeDefinition.Object = schemaObject.ObjectName;
                foreach(Field field in schemaObject.GetFields().Where(f => !f.HasOperation))
                {
                    if (field.DataSize != -1)
                    {
                        ValidationRule validationRule = new ValidationRule()
                        {
                            Field = field.FieldName,
                            Message = field.FieldName + " must be less than or equal to " + field.DataSize + " characters",
                            Condition = new MaxLengthCondition(field.FieldName, field.DataSize)
                        };
                        attributeDefinition.InternalValidationRules.Add(validationRule);
                    }

                    if (field.IsRequired)
                    {
                        ValidationRule validationRule = new ValidationRule()
                        {
                            Field = field.FieldName,
                            Message = field.FieldName + " is a required field.",
                            Condition = new PresenceCondition(field.FieldName)
                        };
                        attributeDefinition.InternalValidationRules.Add(validationRule);
                    }
                }

                UniqueAttribute uniqueAttribute = schemaObject.DataObjectType.GetCustomAttributes(typeof(UniqueAttribute), true).FirstOrDefault() as UniqueAttribute;
                if (uniqueAttribute != null)
                {
                    StringBuilder builder = new StringBuilder();
                    foreach(string field in uniqueAttribute.UniqueFields)
                    {
                        if (builder.Length > 0)
                        {
                            builder.Append(",");
                        }

                        builder.Append(field);
                    }

                    ValidationRule uniqueRule = new ValidationRule()
                    {
                        Field = builder.ToString(),
                        Message = builder.ToString() + " must be unique",
                        Condition = new UniqueCondition(uniqueAttribute.UniqueFields)  
                    };
                    attributeDefinition.InternalValidationRules.Add(uniqueRule);
                }

                if (attributeDefinition.InternalValidationRules.Any())
                {
                    if (!validationDefinitionsBySchemaObject.ContainsKey(schemaObject))
                    {
                        validationDefinitionsBySchemaObject.Add(schemaObject, new List<IValidationDefinition>());
                    }

                    validationDefinitionsBySchemaObject[schemaObject].Add(attributeDefinition);
                }
            }
        }
    }
}
