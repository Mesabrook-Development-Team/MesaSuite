using ReleaseUtility.Extensions;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace ReleaseUtility.Steps
{
    public class RunProgram : IStep
    {
        [DoNotSet]
        public string FriendlyName => "Run a Program";

        public string DisplayName { get; set; }
        public string PathToProgramExecutable { get; set; }

        public void Execute()
        {
            Process process = Process.Start(PathToProgramExecutable);
            process.WaitForExit();
        }

        public void ReadXML(XElement element)
        {
            this.ReadPropertiesFromXML(element);
        }

        public ValidationResult Validate()
        {
            ValidationResult result = new ValidationResult();
            if (string.IsNullOrEmpty(PathToProgramExecutable))
            {
                result.Errors.Add("PathToProgramExecutable is a required field");
                return result;
            }

            if (!File.Exists(PathToProgramExecutable))
            {
                result.AddWarning("Program to run does not yet exist");
            }

            return result;
        }

        public void WriteXML(XElement element)
        {
            element.Add(this.WritePropertiesToXML());
        }
    }
}
