using ClussPro.Base.Data;
using ClussPro.Base.Extensions;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static ClussPro.ObjectBasedFramework.DataObject;

namespace ClussPro.ObjectBasedFramework.Schema
{
    public class SchemaObject
    {
        private TableAttribute table;
        private ConstructorInfo constructor;
        private List<Field> fields = new List<Field>();
        private List<Relationship> relationships = new List<Relationship>();
        private List<RelationshipList> relationshipLists = new List<RelationshipList>();

        Dictionary<string, Field> fieldsByName = new Dictionary<string, Field>();
        Dictionary<string, Relationship> relationshipsByName = new Dictionary<string, Relationship>();
        Dictionary<string, RelationshipList> relationshipListsByName = new Dictionary<string, RelationshipList>();

        public Type DataObjectType { get; private set; }
        public string SchemaName { get; private set; }
        public string ObjectName { get; private set; }
        public Field PrimaryKeyField { get; private set; }
        public bool IsSystemLoaded { get; private set; }
        public string ConnectionName { get; private set; }

        internal SchemaObject(Type type)
        {
            DataObjectType = type;
            table = type.GetCustomAttribute<TableAttribute>();
            constructor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, Type.DefaultBinder, new Type[0], new ParameterModifier[0]);

            SchemaName = table.SchemaName ?? type.Namespace.Substring(type.Namespace.LastIndexOf(".") + 1);
            ObjectName = table.TableName ?? type.Name;
            ConnectionName = table.ConnectionName;

            IsSystemLoaded = typeof(ISystemLoaded).IsAssignableFrom(type);

            if (type.GetCustomAttribute<TableAttribute>(false) == null)
            {
                if (string.IsNullOrEmpty(table.SchemaName) || string.IsNullOrEmpty(table.TableName))
                {
                    Type workingType = type;
                    while(workingType.GetCustomAttribute<TableAttribute>(false) == null)
                    {
                        workingType = workingType.BaseType;
                    }

                    if (string.IsNullOrEmpty(table.SchemaName))
                    {
                        SchemaName = workingType.Namespace.Substring(workingType.Namespace.LastIndexOf(".") + 1);
                    }

                    if (string.IsNullOrEmpty(table.TableName))
                    {
                        ObjectName = workingType.Name;
                    }
                }
            }

            FieldInfo retrievedPathsField = typeof(DataObject).GetField("retrievedPaths", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo originalValuesField = typeof(DataObject).GetField("originalValues", BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (PropertyInfo propertyInfo in type.GetProperties().Where(p => p.GetCustomAttribute<FieldAttribute>() != null ||
                                                                            p.GetCustomAttribute<RelationshipAttribute>() != null ||
                                                                            p.GetCustomAttribute<RelationshipListAttribute>() != null))
            {
                string privatePropertyName = "_" + propertyInfo.Name.Substring(0, 1).ToLower() + propertyInfo.Name.Substring(1);
                FieldInfo fieldInfo = type.GetField(privatePropertyName, BindingFlags.NonPublic | BindingFlags.Instance);

                if (fieldInfo == null && type.BaseType != typeof(DataObject))
                {
                    Type workingType = type;
                    while(workingType.BaseType != typeof(DataObject))
                    {
                        workingType = workingType.BaseType;

                        fieldInfo = workingType.GetField(privatePropertyName, BindingFlags.NonPublic | BindingFlags.Instance);
                        if (fieldInfo != null)
                        {
                            break;
                        }
                    }
                }

                if (propertyInfo.GetCustomAttribute<FieldAttribute>() != null)
                {
                    FieldAttribute fieldAttribute = propertyInfo.GetCustomAttribute<FieldAttribute>();
                    Field field = new Field();

                    field.FieldName = propertyInfo.Name;
                    FieldSpecification.FieldTypes? fieldType = fieldAttribute.FieldType;
                    if (fieldType == null)
                    {
                        Type propType = propertyInfo.PropertyType;
                        if (propType == typeof(string))
                        {
                            fieldType = FieldSpecification.FieldTypes.NVarChar;
                        }
                        else if (propType == typeof(long) || propType == typeof(long?))
                        {
                            fieldType = FieldSpecification.FieldTypes.BigInt;
                        }
                        else if (propType == typeof(byte[]))
                        {
                            fieldType = FieldSpecification.FieldTypes.Binary;
                        }
                        else if (propType == typeof(byte) || propType == typeof(byte?))
                        {
                            fieldType = FieldSpecification.FieldTypes.TinyInt;
                        }
                        else if (propType == typeof(DateTime) || propType == typeof(DateTime?))
                        {
                            fieldType = FieldSpecification.FieldTypes.DateTime2;
                        }
                        else if (propType == typeof(Guid) || propType == typeof(Guid?))
                        {
                            fieldType = FieldSpecification.FieldTypes.UniqueIdentifier;
                        }
                        else if (propType == typeof(bool))
                        {
                            fieldType = FieldSpecification.FieldTypes.Bit;
                        }
                        else if (propType == typeof(int) || propType == typeof(int?))
                        {
                            fieldType = FieldSpecification.FieldTypes.Int;
                        }
                        else if (propType == typeof(decimal) || propType == typeof(decimal?))
                        {
                            fieldType = FieldSpecification.FieldTypes.Decimal;
                        }
                        else if (propType == typeof(short) || propType == typeof(short?))
                        {
                            fieldType = FieldSpecification.FieldTypes.SmallInt;
                        }
                    }
                    field.FieldType = fieldType.Value;
                    field.DataSize = fieldAttribute.DataSize;
                    field.DataScale = fieldAttribute.DataScale;
                    field.SetPrivateDataCallback = (instance, value) =>
                    {
                        object valueToSet = value;
                        if (DBNull.Value.Equals(valueToSet))
                        {
                            valueToSet = null;
                        }

                        fieldInfo.SetValue(instance, valueToSet);
                        HashSet<string> retrievedPaths = (HashSet<string>)retrievedPathsField.GetValue(instance);
                        retrievedPaths.Add(propertyInfo.Name);
                        Dictionary<string, object> originalValues = (Dictionary<string, object>)originalValuesField.GetValue(instance);
                        originalValues[field.FieldName] = valueToSet;
                    };
                    field.GetPrivateDataCallback = (instance) => fieldInfo.GetValue(instance);
                    field.SetValue = propertyInfo.SetValue;
                    field.ParentSchemaObject = this;
                    field.IsRequired = propertyInfo.GetCustomAttribute<RequiredAttribute>() != null;
                    field.IsSystemLoaded = fieldAttribute.IsSystemLoaded;
                    field.IsPrimaryKey = fieldAttribute.IsPrimaryKey;
                    field.HasOperation = fieldAttribute.HasOperation;
                    if (field.HasOperation)
                    {
                        PropertyInfo operationProperty = type.GetProperty(propertyInfo.Name + "Operation", BindingFlags.Static | BindingFlags.Public);
                        field.GetOperation = (alias) =>
                        {
                            OperationDelegate operationDelegate = (OperationDelegate)operationProperty.GetValue(null);
                            return operationDelegate(alias);
                        };
                    }
                    field.ReturnType = propertyInfo.PropertyType;
                    fields.Add(field);
                    fieldsByName.Add(field.FieldName, field);
                }

                RelationshipAttribute relAttribute = null;
                if ((relAttribute = propertyInfo.GetCustomAttribute<RelationshipAttribute>()) != null)
                {
                    Relationship relationship = new Relationship();

                    relationship.RelationshipName = propertyInfo.Name;
                    relationship.RelatedObjectType = fieldInfo.FieldType;
                    relationship.SetPrivateDataCallback = (instance, value) =>
                    {
                        fieldInfo.SetValue(instance, value);
                        HashSet<string> retrievedPaths = (HashSet<string>)retrievedPathsField.GetValue(instance);
                        retrievedPaths.Add(propertyInfo.Name);
                    };
                    relationship.GetPrivateDataCallback = (instance) => fieldInfo.GetValue(instance);
                    relationship.ParentSchemaObject = this;
                    relationship.RelationshipAttribute = relAttribute;
                    relationships.Add(relationship);
                    relationshipsByName.Add(relationship.RelationshipName, relationship);
                }

                if (propertyInfo.GetCustomAttribute<RelationshipListAttribute>() != null)
                {
                    RelationshipListAttribute relationshipListAttribute = propertyInfo.GetCustomAttribute<RelationshipListAttribute>();
                    RelationshipList relationshipList = new RelationshipList();

                    relationshipList.RelationshipListName = propertyInfo.Name;
                    relationshipList.ForeignKeyName = relationshipListAttribute.ForeignKeyName;
                    relationshipList.AutoDeleteReferences = relationshipListAttribute.AutoDeleteReferences;
                    relationshipList.AutoRemoveReferences = relationshipListAttribute.AutoRemoveReferences;

                    Type iEnumerableType = typeof(IEnumerable<DataObject>);
                    if (iEnumerableType.IsAssignableFrom(fieldInfo.FieldType))
                    {
                        Type genericType = fieldInfo.FieldType.GetGenericArguments()[0];
                        relationshipList.RelatedObjectType = genericType;
                    }

                    relationshipList.SetPrivateDataCallback = (instance, value) =>
                    {
                        fieldInfo.SetValue(instance, value);
                        HashSet<string> retrievedPaths = (HashSet<string>)retrievedPathsField.GetValue(instance);
                        retrievedPaths.Add(propertyInfo.Name);
                    };
                    relationshipList.GetPrivateDataCallback = (instance) => fieldInfo.GetValue(instance);
                    relationshipList.ParentSchemaObject = this;
                    relationshipLists.Add(relationshipList);
                    relationshipListsByName.Add(relationshipList.RelationshipListName, relationshipList);
                }
            }

            foreach(Relationship relationship in relationships)
            {
                string fieldName = relationship.RelationshipAttribute.ForeignKeyField ?? relationship.RelationshipName + "ID";
                Field backingField = PrivateGetField(fieldName);
                if (backingField == null)
                {
                    throw new SchemaException("Could not identify backing field for relationship " + relationship.RelationshipName);
                }

                relationship.ForeignKeyField = backingField;
            }

            PrimaryKeyField = PrivateGetField(ObjectName + "ID") ?? fields.FirstOrDefault(f => f.IsPrimaryKey);
        }

        public Field GetField(string fieldName)
        {
            if (fieldName == null) { return null; }

            if (!fieldName.Contains("."))
            {
                return PrivateGetField(fieldName);
            }

            SchemaObject finalSchemaObject = GetFinalSchemaObject(fieldName);
            return finalSchemaObject.PrivateGetField(fieldName.Substring(fieldName.LastIndexOf(".") + 1));
        }

        private SchemaObject GetFinalSchemaObject(string path)
        {
            string[] parts = path.Split('.');
            SchemaObject lastSchemaObject = this;
            for (int i = 0; i < parts.Length - 1; i++)
            {
                Relationship relationship = lastSchemaObject.PrivateGetRelationship(parts[i]);
                if (relationship == null)
                {
                    throw new KeyNotFoundException($"Could not find relationship {parts[i]} on Data Object {lastSchemaObject.SchemaName}.{lastSchemaObject.ObjectName}");
                }

                lastSchemaObject = Schema.GetSchemaObject(relationship.RelatedObjectType);
            }

            return lastSchemaObject;
        }

        private Field PrivateGetField(string fieldName)
        {
            return fieldsByName.GetOrDefault(fieldName);
        }

        public Relationship GetRelationship(string relationshipName)
        {
            if (!relationshipName.Contains("."))
            {
                return PrivateGetRelationship(relationshipName);
            }

            SchemaObject finalSchemaObject = GetFinalSchemaObject(relationshipName);
            return finalSchemaObject.PrivateGetRelationship(relationshipName.Substring(relationshipName.LastIndexOf(".") + 1));
        }

        private Relationship PrivateGetRelationship(string relationshipName)
        {
            return relationshipsByName.GetOrDefault(relationshipName);
        }

        public RelationshipList GetRelationshipList(string relationshipListName)
        {
            if (!relationshipListName.Contains("."))
            {
                return PrivateGetRelationshipList(relationshipListName);
            }

            SchemaObject finalSchemaObject = GetFinalSchemaObject(relationshipListName);
            return finalSchemaObject.PrivateGetRelationshipList(relationshipListName.Substring(relationshipListName.LastIndexOf(".") + 1));
        }

        private RelationshipList PrivateGetRelationshipList(string relationshipListName)
        {
            return relationshipListsByName.GetOrDefault(relationshipListName);
        }

        public IReadOnlyCollection<Field> GetFields()
        {
            return fields;
        }

        public IReadOnlyCollection<Relationship> GetRelationships()
        {
            return relationships;
        }

        public IReadOnlyCollection<RelationshipList> GetRelationshipLists()
        {
            return relationshipLists;
        }

        internal DataObject CreateInstance()
        {
            return (DataObject)constructor.Invoke(new object[0]);
        }
    }
}
