using ReleaseUtility.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReleaseUtility.Steps
{
    public class UploadFilesToFTP : IStep
    {
        [DoNotSet]
        public string FriendlyName => "Upload Files to FTP";
        public string DisplayName { get; set; }

        public string LocalDirectory { get; set; }
        public string RemoteURL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool ReviewFilesBeforeUpload { get; set; }

        public ValidationResult Validate()
        {
            ValidationResult result = new ValidationResult();

            if (string.IsNullOrEmpty(LocalDirectory) || string.IsNullOrEmpty(RemoteURL))
            {
                result.Errors.Add("Required parameter(s) missing");

                return result;
            }

            if (!Directory.Exists(LocalDirectory))
            {
                result.Errors.Add("Local Directory invalid");
            }

            if (!RemoteURL.EndsWith("/"))
            {
                result.Errors.Add("Remote URL must end with '/'");
            }

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                result.AddWarning("Username or password is missing.  FTP access will use anonymous access.");
            }

            return result;
        }

        public void Execute()
        {
            string[] previouslySelected = null;
            if (File.Exists(Path.Combine(LocalDirectory, ".ftpupload")))
            {
                previouslySelected = File.ReadAllLines(Path.Combine(LocalDirectory, ".ftpupload"));
            }

            IEnumerable<string> filesToUpload = Directory.GetFiles(LocalDirectory, "*", SearchOption.AllDirectories).Where(f => !f.EndsWith(".ftpupload"));

            if (ReviewFilesBeforeUpload)
            {
                frmFTPReview review = new frmFTPReview();
                review.Files = filesToUpload;
                review.PreSelected = previouslySelected;
                if (review.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    throw new OperationCanceledException("User canceled FTP upload");
                }

                filesToUpload = review.Files;
            }
            else if (previouslySelected != null)
            {
                filesToUpload = filesToUpload.Intersect(previouslySelected);
            }

            File.WriteAllLines(Path.Combine(LocalDirectory, ".ftpupload"), filesToUpload.ToArray());
            string[] manifest = filesToUpload.Select(f => f.Replace(LocalDirectory, "")).Select(f => { return f.StartsWith("\\") ? f.Substring(1) : f; }).ToArray();
            File.WriteAllLines(Path.Combine(LocalDirectory, "manifest"), manifest);

            if (manifest.Any(m => m.Contains("\\")))
            {
                HashSet<string> checkedDirectories = new HashSet<string>();
                HashSet<string> directoriesToCheck = manifest.Where(m => m.Contains("\\")).Select(m => m.Substring(0, m.LastIndexOf("\\"))).ToHashSet();

                foreach(string directoryToCheck in directoriesToCheck)
                {
                    string workingString = "";
                    string[] directoryParts = directoryToCheck.Split('\\');
                    foreach(string directoryPart in directoryParts)
                    {
                        if (workingString.Length > 0)
                        {
                            workingString += "/";
                        }

                        workingString += directoryPart;
                        if (!checkedDirectories.Add(workingString))
                        {
                            continue;
                        }

                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(RemoteURL + workingString);
                        if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
                        {
                            request.Credentials = new NetworkCredential(Username, Password);
                        }
                        request.Method = WebRequestMethods.Ftp.MakeDirectory;
                        try
                        {
                            request.GetResponse();
                        }
                        catch { }
                    }
                }
            }

            WebClient client = new WebClient();
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                client.Credentials = new NetworkCredential(Username, Password);
            }

            foreach(string file in manifest)
            {
                client.UploadFile(RemoteURL + file, Path.Combine(LocalDirectory, file));
            }

            client.UploadFile(RemoteURL + "manifest", Path.Combine(LocalDirectory, "manifest"));
            File.Delete(Path.Combine(LocalDirectory, "manifest"));
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
