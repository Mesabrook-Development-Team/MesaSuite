using ReleaseUtility.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ReleaseUtility.Steps
{
    public class UpdateConfigs : IStep
    {
        [DoNotSet]
        public string FriendlyName => "Update Config File";
        public string DisplayName { get; set; }

        public string FullPathToConfigFile { get; set; }
        public Dictionary<string, string> AppSettingsUpdates { get; set; } = new Dictionary<string, string>();

        public ValidationResult Validate()
        {
            ValidationResult result = new ValidationResult();

            if (string.IsNullOrEmpty(FullPathToConfigFile))
            {
                result.Errors.Add("Missing required parameter");
                return result;
            }

            if (!File.Exists(FullPathToConfigFile))
            {
                result.Errors.Add("FullPathToConfigFile is invalid");
            }

            if (AppSettingsUpdates.Count == 0)
            {
                result.AddWarning("No AppSettingsUpates entered - this step will do nothing");
            }

            return result;
        }

        public void Execute()
        {
            XDocument configDocument = XDocument.Load(FullPathToConfigFile);
            XElement appSettingsElement = configDocument.Root.XPathSelectElement("//appSettings");

            foreach(KeyValuePair<string, string> update in AppSettingsUpdates)
            {
                XElement elementToUpdate = appSettingsElement.XPathSelectElement("./add[@key='" + update.Key + "']");
                if (elementToUpdate == null)
                {
                    continue;
                }

                elementToUpdate.Attribute("value").Value = update.Value;
            }

            configDocument.Save(FullPathToConfigFile);
        }

        public void ReadXML(XElement element)
        {
            this.ReadPropertiesFromXML(element);
        }

        public void WriteXML(XElement element)
        {
            element.Add(this.WritePropertiesToXML());
        }
    }
}
