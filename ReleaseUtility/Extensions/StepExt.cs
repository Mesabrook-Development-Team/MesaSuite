using ReleaseUtility.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace ReleaseUtility.Extensions
{
    internal static class StepExt
    {
        internal static IEnumerable<XElement> WritePropertiesToXML(this IStep step)
        {
            foreach (PropertyInfo propInfo in step.GetType().GetProperties().Where(prop => !prop.GetCustomAttributes(typeof(DoNotSetAttribute)).Any()))
            {
                XElement element = new XElement(propInfo.Name);

                if (propInfo.PropertyType == typeof(string))
                {
                    element.Value = (string)propInfo.GetValue(step) ?? "";
                }
                else if (propInfo.PropertyType == typeof(List<string>))
                {
                    foreach(string valueItem in (List<string>)propInfo.GetValue(step))
                    {
                        XElement valueElement = new XElement("Value", valueItem);
                        element.Add(valueElement);
                    }
                }
                else if (propInfo.PropertyType == typeof(bool))
                {
                    element.Value = ((bool)propInfo.GetValue(step)).ToString();
                }
                else if (propInfo.PropertyType == typeof(Dictionary<string, string>))
                {
                    foreach (KeyValuePair<string, string> valueKVP in (Dictionary<string, string>)propInfo.GetValue(step))
                    {
                        XElement valueElement = new XElement("Value", new XAttribute("key", valueKVP.Key), valueKVP.Value);
                        element.Add(valueElement);
                    }
                }

                yield return element;
            }
        }

        internal static void ReadPropertiesFromXML(this IStep step, XElement element)
        {
            Type stepType = step.GetType();
            foreach(XElement child in element.Elements())
            {
                PropertyInfo propertyInfo = stepType.GetProperty(child.Name.LocalName);
                if (propertyInfo == null)
                {
                    continue;
                }

                if (propertyInfo.GetCustomAttribute<DoNotSetAttribute>() != null)
                {
                    continue;
                }

                if (propertyInfo.PropertyType == typeof(string))
                {
                    propertyInfo.SetValue(step, child.Value);
                }
                else if (propertyInfo.PropertyType == typeof(List<string>))
                {
                    List<string> valueList = new List<string>();
                    foreach(XElement valueElement in child.Elements("Value"))
                    {
                        valueList.Add(valueElement.Value);
                    }

                    propertyInfo.SetValue(step, valueList);
                }
                else if (propertyInfo.PropertyType == typeof(bool))
                {
                    propertyInfo.SetValue(step, bool.Parse(child.Value));
                }
                else if (propertyInfo.PropertyType == typeof(Dictionary<string, string>))
                {
                    Dictionary<string, string> valueDictionary = new Dictionary<string, string>();
                    foreach(XElement valueElement in child.Elements("Value"))
                    {
                        valueDictionary.Add(valueElement.Attribute("key").Value, valueElement.Value);
                    }

                    propertyInfo.SetValue(step, valueDictionary);
                }
            }
        }
    }
}
