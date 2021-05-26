using ReleaseUtility.Extensions;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace ReleaseUtility.Steps
{
    public class ResetChanges : IStep
    {
        [DoNotSet]
        public string FriendlyName => "Reset Git Branch";
        public string DisplayName { get; set; }

        public string PathToGitRepo { get; set; }

        public ValidationResult Validate()
        {
            ValidationResult result = new ValidationResult();

            if (string.IsNullOrEmpty(PathToGitRepo))
            {
                result.Errors.Add("Missing required parameter");
                return result;
            }

            if (!Directory.Exists(PathToGitRepo))
            {
                result.Errors.Add("PathToGitRepo is invalid");
            }

            return result;
        }

        public void Execute()
        {
            Guid batchName = Guid.NewGuid();
            File.WriteAllText($"{batchName.ToString("N")}.bat", $"cd {PathToGitRepo}\r\ngit reset --hard");

            ProcessStartInfo startInfo = new ProcessStartInfo($"{batchName.ToString("N")}.bat");
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;

            Process process = Process.Start(startInfo);

            process.WaitForExit(300000);

            if (!process.HasExited)
            {
                throw new TimeoutException("The process did not complete in a timely fashion.");
            }

            File.Delete($"{batchName.ToString("N")}.bat");

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
