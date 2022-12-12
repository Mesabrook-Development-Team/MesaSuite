using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using MesaSuite.Common;
using MesaSuite.Common.Extensions;

namespace MCSync
{
    public class Syncer
    {
        public event EventHandler SyncComplete;
        public event EventHandler<Task> TaskAdded;

        public enum SyncMode
        {
            Client,
            Server
        }

        public async void BeginSync()
        {
            await System.Threading.Tasks.Task.Run(DoSync);
        }

        public static bool IsDownloadTypeValid(SyncMode mode, MCSyncFile.DownloadTypes downloadTypes)
        {
            if(downloadTypes == MCSyncFile.DownloadTypes.Client && mode == SyncMode.Client)
            {
                return true;
            }
            else if (downloadTypes == MCSyncFile.DownloadTypes.Server && mode == SyncMode.Server)
            {
                return true;
            }
            else if (downloadTypes == MCSyncFile.DownloadTypes.Common)
            {
                return true;
            }
            return false;
        }

        private async System.Threading.Tasks.Task DoSync()
        {
            try
            {
                Task.Informations.Clear();
                Task.Errors.Clear();

                // Load config
                Dictionary<string, object> configValues = UserPreferences.Get().Sections.GetOrSetDefault("mcsync", new Dictionary<string, object>());

                if (!configValues.ContainsKey("modsDirectory") || !configValues.ContainsKey("resourcePackDirectory") || !configValues.ContainsKey("configFilesDirectory") || !configValues.ContainsKey("mode") ||
                    string.IsNullOrEmpty(configValues.GetOrDefault("modsDirectory", string.Empty).Cast<string>()) || string.IsNullOrEmpty(configValues.GetOrDefault("resourcePackDirectory", "").Cast<string>()) || string.IsNullOrEmpty(configValues.GetOrDefault("configFilesDirectory", "").Cast<string>()) || !Enum.TryParse(configValues["mode"].Cast<string>(), true, out SyncMode configSyncMode) ||
                    (configSyncMode == SyncMode.Client && (!configValues.ContainsKey("oResourcesDirectory") || string.IsNullOrEmpty(configValues["oResourcesDirectory"].Cast<string>()))))
                {
                    Task.Errors.Add("Configuration file not setup");
                    SyncComplete?.Invoke(this, new EventArgs());
                    return;
                }

                string modsDirectory = configValues["modsDirectory"].Cast<string>();
                string resourcePackDirectory = configValues["resourcePackDirectory"].Cast<string>();
                string configFilesDirectory = configValues["configFilesDirectory"].Cast<string>();
                string oResourcesDirectory = configValues["oResourcesDirectory"].Cast<string>();
                string animationDirectory = configValues["animationDirectory"].Cast<string>();

                string[] clientSideWhiteListMods = UserPreferences.Get().Sections.GetOrDefault("mcsync", new Dictionary<string, object>()).GetOrDefault("mods_whitelist")?.Cast<string[]>() ?? new string[0];
                string[] clientSideWhiteListResourcePacks = UserPreferences.Get().Sections.GetOrDefault("mcsync", new Dictionary<string, object>()).GetOrDefault("resourcepacks_whitelist")?.Cast<string[]>() ?? new string[0];

                List<Task> tasks = new List<Task>();

                // Create Required Subdirectories
                Directory.CreateDirectory(animationDirectory);
                Directory.CreateDirectory(modsDirectory);
                Directory.CreateDirectory(resourcePackDirectory);
                Directory.CreateDirectory(configFilesDirectory);
                Directory.CreateDirectory(oResourcesDirectory);

                // Load database stuff
                List<MCSyncFile> syncFiles = await MCSyncFile.GetMCSyncFiles();

                // Drive off of files
                List<string> handledFiles = new List<string>();

                // Mod Files
                IEnumerable<MCSyncFile> modSyncFiles = syncFiles.Where(f => f.FileType == MCSyncFile.FileTypes.mods && IsDownloadTypeValid(configSyncMode, f.DownloadType));
                foreach (string file in Directory.EnumerateFiles(modsDirectory, "*", SearchOption.AllDirectories))
                {
                    string strippedFile = StripDirectory(file, MCSyncFile.FileTypes.mods);
                    byte[] fileHash = CalculateHash(file);
                    MCSyncFile syncFile = modSyncFiles.FirstOrDefault(f => f.Filename == strippedFile);
                    if (syncFile == null)
                    {
                        if (!clientSideWhiteListMods.Contains(strippedFile))
                        {
                            // Extrinsic, delete
                            Task deleteTask = new Task($"Delete mod file {strippedFile}", () =>
                            {
                                File.Delete(file);
                                return true;
                            });
                            tasks.Add(deleteTask);
                            TaskAdded?.Invoke(this, deleteTask);
                        }
                    }
                    else if (!syncFile.Checksum.SequenceEqual(fileHash))
                    {
                        Task updateTask = new Task($"Update mod file {strippedFile}", () => DownloadFile(syncFile.FileType, modsDirectory, strippedFile, syncFile.DownloadType));
                        tasks.Add(updateTask);
                        TaskAdded?.Invoke(this, updateTask);
                    }

                    handledFiles.Add(strippedFile);
                }

                bool resourcePackChanges = false;
                // Resource Pack Files
                IEnumerable<MCSyncFile> resourcePackSyncFiles = syncFiles.Where(f => f.FileType == MCSyncFile.FileTypes.resourcepacks && IsDownloadTypeValid(configSyncMode, f.DownloadType));
                foreach (string file in Directory.EnumerateFiles(resourcePackDirectory, "*", SearchOption.AllDirectories))
                {
                    string strippedFile = StripDirectory(file, MCSyncFile.FileTypes.resourcepacks);
                    byte[] fileHash = CalculateHash(file);
                    MCSyncFile syncFile = resourcePackSyncFiles.FirstOrDefault(f => f.Filename == strippedFile);
                    if (syncFile == null)
                    {
                        if (!clientSideWhiteListResourcePacks.Contains(strippedFile))
                        {
                            resourcePackChanges = true;
                            // Extrinsic, delete
                            Task deleteTask = new Task($"Delete resource pack file {strippedFile}", () =>
                            {
                                File.Delete(file);
                                return true;
                            });
                            tasks.Add(deleteTask);
                            TaskAdded?.Invoke(this, deleteTask);
                        }
                    }
                    else if (!syncFile.Checksum.SequenceEqual(fileHash))
                    {
                        resourcePackChanges = true;
                        Task updateTask = new Task($"Update resource pack file {strippedFile}", () => DownloadFile(syncFile.FileType, resourcePackDirectory, strippedFile, syncFile.DownloadType));
                        tasks.Add(updateTask);
                        TaskAdded?.Invoke(this, updateTask);
                    }

                    handledFiles.Add(strippedFile);
                }

                // Config
                IEnumerable<MCSyncFile> configSyncFiles = syncFiles.Where(f => f.FileType == MCSyncFile.FileTypes.config && IsDownloadTypeValid(configSyncMode, f.DownloadType));
                foreach(MCSyncFile configFile in configSyncFiles)
                {
                    if (File.Exists(configFilesDirectory + "\\" + configFile.Filename))
                    {
                        byte[] fileHash = CalculateHash(configFilesDirectory + "\\" + configFile.Filename);
                        if (!fileHash.SequenceEqual(configFile.Checksum))
                        {
                            Task updateTask = new Task($"Update config file {configFile.Filename}", () => DownloadFile(configFile.FileType, configFilesDirectory, configFile.Filename, configFile.DownloadType));
                            tasks.Add(updateTask);
                            TaskAdded?.Invoke(this, updateTask);
                        }

                        handledFiles.Add(configFile.Filename);
                    }
                }

                // Splash Animation PNG Files
                IEnumerable<MCSyncFile> animationSyncFiles = syncFiles.Where(f => f.FileType == MCSyncFile.FileTypes.animation && IsDownloadTypeValid(configSyncMode, f.DownloadType));
                foreach (string file in Directory.EnumerateFiles(animationDirectory, "*", SearchOption.AllDirectories))
                {
                    string strippedFile = StripDirectory(file, MCSyncFile.FileTypes.oresources);
                    byte[] fileHash = CalculateHash(file);
                    MCSyncFile syncFile = animationSyncFiles.FirstOrDefault(f => f.Filename == strippedFile);
                    if (syncFile == null)
                    {
                        // Extrinsic, delete
                        Task deleteTask = new Task($"Delete animation file {strippedFile}", () =>
                        {
                            File.Delete(file);
                            return true;
                        });
                        tasks.Add(deleteTask);
                        TaskAdded?.Invoke(this, deleteTask);
                    }
                    else if (!syncFile.Checksum.SequenceEqual(fileHash))
                    {
                        Task updateTask = new Task($"Update animation file {strippedFile}", () => DownloadFile(syncFile.FileType, animationDirectory, strippedFile, syncFile.DownloadType));
                        tasks.Add(updateTask);
                        TaskAdded?.Invoke(this, updateTask);
                    }

                    handledFiles.Add(strippedFile);
                }

                // OResources Files
                IEnumerable<MCSyncFile> oResourcesSyncFiles = syncFiles.Where(f => f.FileType == MCSyncFile.FileTypes.oresources && IsDownloadTypeValid(configSyncMode, f.DownloadType));
                foreach (string file in Directory.EnumerateFiles(oResourcesDirectory, "*", SearchOption.AllDirectories))
                {
                    string strippedFile = StripDirectory(file, MCSyncFile.FileTypes.oresources);
                    byte[] fileHash = CalculateHash(file);
                    MCSyncFile syncFile = oResourcesSyncFiles.FirstOrDefault(f => f.Filename == strippedFile);
                    if (syncFile == null)
                    {
                        // Extrinsic, delete
                        Task deleteTask = new Task($"Delete oresource file {strippedFile}", () =>
                        {
                            File.Delete(file);
                            return true;
                        });
                        tasks.Add(deleteTask);
                        TaskAdded?.Invoke(this, deleteTask);
                    }
                    else if (!syncFile.Checksum.SequenceEqual(fileHash))
                    {
                        Task updateTask = new Task($"Update oresource file {strippedFile}", () => DownloadFile(syncFile.FileType, oResourcesDirectory, strippedFile, syncFile.DownloadType));
                        tasks.Add(updateTask);
                        TaskAdded?.Invoke(this, updateTask);
                    }

                    handledFiles.Add(strippedFile);
                }

                // Missing Files
                IEnumerable<MCSyncFile> missingFiles = syncFiles.Where(f => IsDownloadTypeValid(configSyncMode, f.DownloadType) && !handledFiles.Contains(f.Filename));
                foreach (MCSyncFile missingFile in missingFiles)
                {
                    if (missingFile.FileType == MCSyncFile.FileTypes.resourcepacks)
                    {
                        Task.Informations.Add($"The resource pack {missingFile.Filename} has been added.  Make sure to select it under the 'Available Resource Packs' column in the 'Options...'->'Resource Packs...' menu in Minecraft before attempting to join the server!");
                    }

                    string directory = "";
                    switch(missingFile.FileType)
                    {
                        case MCSyncFile.FileTypes.mods:
                            directory = modsDirectory;
                            break;
                        case MCSyncFile.FileTypes.resourcepacks:
                            resourcePackChanges = true;
                            directory = resourcePackDirectory;
                            break;
                        case MCSyncFile.FileTypes.config:
                            directory = configFilesDirectory;
                            break;
                        case MCSyncFile.FileTypes.oresources:
                            directory = oResourcesDirectory;
                            break;
                        case MCSyncFile.FileTypes.animation:
                            directory = animationDirectory;
                            break;
                    }

                    Task downloadTask = new Task($"Download {missingFile.FileType.ToString()} file {missingFile.Filename}", () => DownloadFile(missingFile.FileType, directory, missingFile.Filename, missingFile.DownloadType));
                    tasks.Add(downloadTask);
                    TaskAdded?.Invoke(this, downloadTask);
                }

                if (resourcePackChanges)
                {
                    Task deleteCaches = new Task("Delete Immersive Railroading caches", () =>
                    {
                        if (!Directory.Exists(modsDirectory + "\\..\\cache\\universalmodcore"))
                        {
                            Task.Errors.Add("Could not find cache folder. New textures may appear incorrectly, not appear at all, or appear as the default texture. Please delete your cache folder manually.");
                            return false;
                        }

                        bool errorsOccurred = false;
                        foreach(string file in Directory.EnumerateFiles(modsDirectory + "\\..\\cache\\universalmodcore", "*", SearchOption.AllDirectories))
                        {
                            try
                            {
                                File.Delete(file);
                            }
                            catch(Exception ex)
                            {
                                Task.Errors.Add("Could not delete cached file " + file + "\r\n" + ex.Message);
                                errorsOccurred = true;
                            }
                        }

                        return !errorsOccurred;
                    });
                    tasks.Add(deleteCaches);
                    TaskAdded?.Invoke(this, deleteCaches);
                }

                // Perform Tasks
                foreach (Task task in tasks)
                {
                    task.Execute();
                }
            }
            catch (Exception ex)
            {
                Task.Errors.Add($"An unexpected error occurred during Sync: {ex.Message}");
            }

            SyncComplete?.Invoke(this, new EventArgs());
        }

        private byte[] CalculateHash(string file)
        {
            using (MD5 md5 = MD5.Create())
            using (Stream fileStream = File.OpenRead(file))
            {
                return md5.ComputeHash(fileStream);
            }
        }

        private string StripDirectory(string file, MCSyncFile.FileTypes fileType)
        {
            if (!file.Contains(fileType.ToString().ToLower() + "\\"))
            {
                return file;
            }

            return file.Substring(file.LastIndexOf(fileType.ToString().ToLower() + "\\") + fileType.ToString().Length + 1);
        }

        private bool DownloadFile(MCSyncFile.FileTypes type, string directory, string file, MCSyncFile.DownloadTypes downloadTypes)
        {
            try
            {
                FtpWebRequest webRequest = (FtpWebRequest)WebRequest.Create("ftp://www.clussmanproductions.com/support/MCSyncNew/" + downloadTypes.ToString().ToLower() + "/" + type.ToString() + "/" + StripDirectory(file, type));
                webRequest.Credentials = new NetworkCredential("Reporting", "NetLogon");
                webRequest.Method = WebRequestMethods.Ftp.DownloadFile;

                FtpWebResponse response = (FtpWebResponse)webRequest.GetResponse();

                if (!Directory.Exists(Path.GetDirectoryName(directory + "\\" + file)))
                {
                    string path = Path.GetDirectoryName(directory + "\\" + file);
                    Directory.CreateDirectory(path);
                }

                File.Delete(directory + "\\" + file);

                using (Stream responseStream = response.GetResponseStream())
                using (Stream fileStream = File.OpenWrite(directory + "\\" + file))
                {
                    responseStream.CopyTo(fileStream);
                }

                return true;
            }
            catch (Exception ex)
            {
                Task.Errors.Add(ex.Message);
                return false;
            }
        }
    }
}
