using ReleaseUtility.Extensions;
using System;
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
        public string Arguments { get; set; }

        public void Execute()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(PathToProgramExecutable, Arguments);
            Process process = Process.Start(processStartInfo);
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new Exception("The process did not complete successfully!");
            }
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
