using System.Collections.Generic;
using System.Linq;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Validation.Conditions;

namespace WebModels.mesasys.Validations
{
    internal class HasValidBindingsCondition : Condition
    {
        public string SemiColonDelimitedAllowedFieldListFieldName { get; set; }
        public string FieldToValidate { get; set; }

        public HasValidBindingsCondition(string semiColonDelimitedAllowedFieldListFieldName, string fieldToValidate)
        {
            SemiColonDelimitedAllowedFieldListFieldName = semiColonDelimitedAllowedFieldListFieldName;
            FieldToValidate = fieldToValidate;
        }

        public override IEnumerable<string> AdditionalDataObjectFields => new [] { SemiColonDelimitedAllowedFieldListFieldName };

        public override bool Evaluate(DataObject dataObject)
        {
            string semiColonDelimitedFieldList = GetSemiColonDelimitedFieldList(dataObject);
            string[] validBindings = semiColonDelimitedFieldList.Split(';');

            string workingString = dataObject.GetField(FieldToValidate).GetValue(dataObject) as string;
            while(workingString.Contains('{'))
            {
                workingString = workingString.Substring(workingString.IndexOf('{') + 1);
                if (!workingString.Contains('}'))
                {
                    return false;
                }

                string binding = workingString.Substring(0, workingString.IndexOf('}'));
                if (binding.Contains(":"))
                {
                    binding = binding.Substring(0, binding.IndexOf(":"));
                }

                if (!validBindings.Contains(binding))
                {
                    return false;
                }
            }

            return true;
        }

        private string GetSemiColonDelimitedFieldList(DataObject dataObject)
        {
            if (!SemiColonDelimitedAllowedFieldListFieldName.Contains('.'))
            {
                return dataObject.GetField(SemiColonDelimitedAllowedFieldListFieldName).GetValue(dataObject) as string;
            }

            string[] parts = SemiColonDelimitedAllowedFieldListFieldName.Split('.');
            SchemaObject lastSchemaObject = Schema.GetSchemaObject(dataObject.GetType());
            DataObject lastObject = dataObject;
            for(int i = 0; i < parts.Length - 1; i++)
            {
                string relationship = parts[i];
                Relationship schemaRelationship = lastSchemaObject.GetRelationship(relationship);
                lastObject = schemaRelationship.GetValue(lastObject);
                lastSchemaObject = schemaRelationship.RelatedSchemaObject;
            }

            return lastObject.GetField(parts[parts.Length - 1]).GetValue(lastObject) as string;
        }
    }
}
