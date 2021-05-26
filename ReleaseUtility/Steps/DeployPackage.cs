using ReleaseUtility.Extensions;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ReleaseUtility.Steps
{
    public class DeployPackage : IStep
    {
        [DoNotSet]
        public string FriendlyName => "Deploy Web Package";
        public string DisplayName { get; set; }

        public string PackagePath { get; set; }
        public string WebsiteName { get; set; }
        public string ComputerName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ValidationResult Validate()
        {
            ValidationResult result = new ValidationResult();
            if (string.IsNullOrEmpty(PackagePath) ||
                string.IsNullOrEmpty(WebsiteName) ||
                string.IsNullOrEmpty(ComputerName) ||
                string.IsNullOrEmpty(Username) ||
                string.IsNullOrEmpty(Password))
            {
                result.Errors.Add("Required property(s) are missing");
            }

            string[] foundFiles;
            try
            {
                foundFiles = Directory.GetFiles(PackagePath, "*.cmd");
            }
            catch
            {
                result.Errors.Add("Could not find a .cmd file for deployment");
                return result;
            }

            string cmdFile = foundFiles[0].Substring(foundFiles[0].LastIndexOf('\\') + 1);
            string projectName = cmdFile.Split('.')[0];
            string setParametersFile = $"{projectName}.SetParameters.xml";

            if (!File.Exists(Path.Combine(PackagePath, setParametersFile)))
            {
                result.Errors.Add($"Could not find {setParametersFile}");
            }

            return result;
        }

        public void Execute()
        {
            string[] foundFiles = Directory.GetFiles(PackagePath, "*.cmd");
            string cmdFile = foundFiles[0].Substring(foundFiles[0].LastIndexOf('\\') + 1);
            string projectName = cmdFile.Split('.')[0];
            string setParametersFile = $"{projectName}.SetParameters.xml";

            XDocument document = XDocument.Load(Path.Combine(PackagePath, setParametersFile));
            XElement element = document.Root.XPathSelectElement("/parameters/setParameter[@name='IIS Web Application Name']");
            element.Attribute("value").Value = $"{WebsiteName}/";
            document.Save(Path.Combine(PackagePath, setParametersFile));

            ProcessStartInfo startInfo = new ProcessStartInfo(Path.Combine(PackagePath, $"{projectName}.deploy.cmd"), $"/Y /M:{ComputerName} /U:{Username} /P:{Password}");
            startInfo.WorkingDirectory = PackagePath;
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            Process process = Process.Start(startInfo);

            process.WaitForExit(300000); // 5 minute max

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
