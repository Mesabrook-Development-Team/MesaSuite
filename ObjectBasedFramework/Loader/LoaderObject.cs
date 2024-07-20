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
                if (elementInit.Arguments.Count != 2)
                {
                    continue;
                }

                MemberExpression loadedObjectProperty = null;
                ConstantExpression loadedObjectValueAsConstant = null;
                MemberExpression loadedObjectValueAsProperty = null;

                if (elementInit.Arguments[0] is UnaryExpression arg0UnaryExpression && arg0UnaryExpression.Operand is MemberExpression)
                {
                    loadedObjectProperty = (MemberExpression)arg0UnaryExpression.Operand;
                }
                else if (elementInit.Arguments[0] is MemberExpression)
                {
                    loadedObjectProperty = (MemberExpression)elementInit.Arguments[0];
                }

                if (elementInit.Arguments[1] is UnaryExpression arg1UnaryExpression)
                {
                    if (arg1UnaryExpression.Operand is ConstantExpression)
                    {
                        loadedObjectValueAsConstant = (ConstantExpression)arg1UnaryExpression.Operand;
                    }
                    else if (arg1UnaryExpression.Operand is MemberExpression)
                    {
                        loadedObjectValueAsProperty = (MemberExpression)arg1UnaryExpression.Operand;
                    }
                }
                else if (elementInit.Arguments[1] is ConstantExpression)
                {
                    loadedObjectValueAsConstant = (ConstantExpression)elementInit.Arguments[1];
                }
                else if (elementInit.Arguments[1] is MemberExpression)
                {
                    loadedObjectValueAsProperty = (MemberExpression)elementInit.Arguments[1];
                }

                if (elementInit.Arguments.Count != 2 ||
                    loadedObjectProperty == null ||
                    (loadedObjectValueAsConstant == null && loadedObjectValueAsProperty == null) ||
                    !(loadedObjectProperty.Member is PropertyInfo propertyInfo) ||
                    (loadedObjectValueAsProperty != null && !(loadedObjectValueAsProperty.Member is PropertyInfo)))
                {
                    continue;
                }

                if (loadedObjectValueAsConstant != null)
                {
                    returnValue[propertyInfo.Name] = loadedObjectValueAsConstant.Value;
                }
                else
                {
                    UnaryExpression objectMember = Expression.Convert(loadedObjectValueAsProperty, typeof(object));
                    LambdaExpression getterLambda = Expression.Lambda<Func<object>>(objectMember);
                    Delegate getter = getterLambda.Compile();

                    returnValue[propertyInfo.Name] = getter.DynamicInvoke();
                }
            }

            return returnValue;
        }
    }
}
