using ClussPro.Base.Data.Operand;
using ClussPro.ObjectBasedFramework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace API_System.Extensions
{
    public static class DataObjectExtensions
    {
        public static void PatchData(this DataObject dataObject, string method, Dictionary<string, object> valuesToUpdate)
        {
            foreach(KeyValuePair<string, object> valueToUpdate in valuesToUpdate)
            {
                KeyValuePair<string, object> workingValueToUpdate = new KeyValuePair<string, object>(valueToUpdate.Key, valueToUpdate.Value);

                PropertyInfo property = dataObject.GetType().GetProperty(workingValueToUpdate.Key);
                bool isEnumerable = typeof(IEnumerable).IsAssignableFrom(property.PropertyType);

                MethodInfo addMethod = null;
                MethodInfo removeMethod = null;
                if (isEnumerable)
                {
                    addMethod = property.GetValue(dataObject).GetType().GetMethod("Add");
                    removeMethod = property.GetValue(dataObject).GetType().GetMethod("Remove");

                    if (workingValueToUpdate.Value is JArray)
                    {
                        JArray array = (JArray)workingValueToUpdate.Value;
                        workingValueToUpdate = new KeyValuePair<string, object>(workingValueToUpdate.Key, array.ToObject(property.PropertyType));
                    }
                }

                switch(method)
                {
                    case "add":
                        if (!isEnumerable)
                        {
                            continue;
                        }

                        if (typeof(IEnumerable).IsAssignableFrom(workingValueToUpdate.Value.GetType()))
                        {
                            foreach (object value in (IEnumerable)workingValueToUpdate.Value)
                            {
                                addMethod.Invoke(property.GetValue(dataObject), new object[] { value });
                            }
                        }
                        else
                        {
                            addMethod.Invoke(property.GetValue(dataObject), new object[] { workingValueToUpdate.Value });
                        }
                        break;
                    case "replace":
                        property.SetValue(dataObject, workingValueToUpdate.Value);
                        break;
                    case "remove":
                        if (!isEnumerable)
                        {
                            continue;
                        }

                        if (typeof(IEnumerable).IsAssignableFrom(workingValueToUpdate.Value.GetType()))
                        {
                            foreach (object value in (IEnumerable)workingValueToUpdate.Value)
                            {
                                removeMethod.Invoke(property.GetValue(dataObject), new object[] { value });
                            }
                        }
                        else
                        {
                            removeMethod.Invoke(property.GetValue(dataObject), new object[] { workingValueToUpdate.Value });
                        }
                        break;
                }
            }
        }
    }
}