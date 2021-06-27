using ClussPro.ObjectBasedFramework.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace ClussPro.ObjectBasedFramework.Loader
{
    public class LoaderObject
    {
        public Type DataObjectType { get; set; }

        public LoaderObject(Type dataObjectType)
        {
            DataObjectType = dataObjectType;
        }

        public Guid SystemID { get; set; }
        public Dictionary<string, object> Values { get; set; }

        internal byte[] CalculateHash()
        {
            Dictionary<string, object> setValues = GetValuesByField();

            SchemaObject thisObject = Schema.Schema.GetSchemaObject(DataObjectType);
            StringBuilder hashStringBuilder = new StringBuilder();
            foreach (Field field in thisObject.GetFields().Where(f => f.IsSystemLoaded))
            {
                hashStringBuilder.Append($"{field.FieldName}=");

                if (setValues.ContainsKey(field.FieldName))
                {
                    hashStringBuilder.Append(setValues[field.FieldName]);
                }

                hashStringBuilder.Append(";");
            }

            string hashString = hashStringBuilder.ToString();

            using (MD5 md5 = MD5.Create())
            {
                return md5.ComputeHash(Encoding.UTF8.GetBytes(hashString));
            }
        }

        public virtual Dictionary<string, object> GetValuesByField()
        {
            return Values;
        }
    }

    public class LoaderObject<T> : LoaderObject where T:DataObject, ISystemLoaded
    {
        public Expression<Func<T, Dictionary<object, object>>> DataObjectValues { get; set; }

        public LoaderObject(Guid systemID) : base(typeof(T))
        {
            SystemID = systemID;
        }

        public LoaderObject(string systemID) : this(new Guid(systemID)) { }

        public override Dictionary<string, object> GetValuesByField()
        {
            Dictionary<string, object> returnValue = new Dictionary<string, object>();

            if (!(DataObjectValues.Body is ListInitExpression listInitExpression))
            {
                return returnValue;
            }

            foreach(ElementInit elementInit in listInitExpression.Initializers.OfType<ElementInit>())
            {
                if (elementInit.Arguments.Count != 2 ||
                    !(elementInit.Arguments[0] is MemberExpression memberExpression) ||
                    !(elementInit.Arguments[1] is ConstantExpression constantExpression) ||
                    !(memberExpression.Member is PropertyInfo propertyInfo))
                {
                    continue;
                }

                returnValue[propertyInfo.Name] = constantExpression.Value;
            }

            return returnValue;
        }
    }
}
