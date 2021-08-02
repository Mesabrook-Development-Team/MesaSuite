using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Validation.Conditions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebModels.hMailServer.Validations.Conditions
{
    public class EndsWithOtherFieldCondition<TDataObject> : Condition where TDataObject:DataObject
    {
        public EndsWithOtherFieldCondition() : base() { }

        public EndsWithOtherFieldCondition(string field, Expression<Func<TDataObject, string>> endsWithField)
        {
            Field = field;
            EndsWithField = endsWithField;
        }

        public string Field { get; set; }
        public Expression<Func<TDataObject, string>> EndsWithField { get; set; }

        public override IEnumerable<string> AdditionalDataObjectFields
        {
            get
            {
                string expressionBody = EndsWithField.Body.ToString();
                expressionBody = expressionBody.Substring(expressionBody.IndexOf('.') + 1);

                if (!expressionBody.Contains("."))
                {
                    yield break;
                }
                else
                {
                    yield return expressionBody;
                }
            }
        }

        public override bool Evaluate(DataObject dataObject)
        {
            SchemaObject schemaObject = Schema.GetSchemaObject(dataObject.GetType());
            Field field = schemaObject.GetField(Field);

            string value = field.GetValue(dataObject) as string;

            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            Func<TDataObject, string> endsWithFunc = EndsWithField.Compile();
            string otherFieldValue = endsWithFunc((TDataObject)dataObject);

            return value.EndsWith(otherFieldValue);
        }
    }
}
