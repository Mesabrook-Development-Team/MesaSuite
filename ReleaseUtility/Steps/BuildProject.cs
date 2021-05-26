using ReleaseUtility.Extensions;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace ReleaseUtility.Steps
{
    public class BuildProject : IStep
    {
        [DoNotSet]
        public string FriendlyName => "Release Build Project";
        public string DisplayName { get; set; }

        public string MSBuildPath { get; set; }
        public string FullCSProjPath { get; set; }

        public ValidationResult Validate()
        {
            ValidationResult result = new ValidationResult();

            if (string.IsNullOrEmpty(MSBuildPath) || string.IsNullOrEmpty(FullCSProjPath))
            {
                result.Errors.Add("Required parameter(s) missing");
                return result;
            }

            if (!File.Exists(MSBuildPath))
            {
                result.Errors.Add("MSBuildPath is invalid");
            }

            if (!File.Exists(FullCSProjPath))
            {
                result.Errors.Add("FullCSProjPath is invalid");
            }

            return result;
        }

        public void Execute()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(MSBuildPath, FullCSProjPath + " /r /p:Configuration=Release");
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            Process process = Process.Start(startInfo);

            process.WaitForExit(300000);

            if (!process.HasExited)
            {
                throw new TimeoutException("The process did not complete in a timely fashion.");
            }

            if (process.ExitCode != 0)
            {
                throw new Exception("The process did not complete successfully!");
            }
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
