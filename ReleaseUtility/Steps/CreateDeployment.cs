using ReleaseUtility.Extensions;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace ReleaseUtility.Steps
{
    public class CreateDeployment : IStep
    {
        [DoNotSet]
        public string FriendlyName => "Create Deployment Package";
        public string DisplayName { get; set; }

        public string MSBuildPath { get; set; }
        public string FullCSProjPath { get; set; }
        public string DeploymentProfileName { get; set; }

        public void Execute()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(MSBuildPath, $"{FullCSProjPath} /r /p:DeployOnBuild=true /p:PublishProfile={DeploymentProfileName}");
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

        public ValidationResult Validate()
        {
            ValidationResult result = new ValidationResult();
            if (string.IsNullOrEmpty(FullCSProjPath) ||
                string.IsNullOrEmpty(DeploymentProfileName) ||
                string.IsNullOrEmpty(MSBuildPath))
            {
                result.Errors.Add("Missing required parameter(s)");
                return result;
            }

            if (!File.Exists(FullCSProjPath))
            {
                result.Errors.Add("Full CS Project path is invalid");
            }

            if (!File.Exists(MSBuildPath))
            {
                result.Errors.Add("MSBuild path is invalid");
            }

            return result;
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
