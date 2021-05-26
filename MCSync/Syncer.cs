using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MCSync
{
    public class Syncer
    {
        public event EventHandler SyncComplete;
        public event EventHandler<Task> TaskAdded;

        public async void BeginSync()
        {
            await DoSync();
        }

        public static bool IsDownloadTypeValid(Config.Modes mode, MCSyncFile.DownloadTypes downloadTypes)
        {
            if(downloadTypes == MCSyncFile.DownloadTypes.Client && mode == Config.Modes.Client)
            {
                return true;
            }
            else if (downloadTypes == MCSyncFile.DownloadTypes.Server && mode == Config.Modes.Server)
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
                // Load config
                Config config = Config.LoadConfiguration();
                if (string.IsNullOrEmpty(config.ModsDirectory) || string.IsNullOrEmpty(config.ResourcePackDirectory) || string.IsNullOrEmpty(config.ConfigFilesDirectory))
                {
                    Task.Errors.Add("Configuration file not setup");
                    SyncComplete?.Invoke(this, new EventArgs());
                    return;
                }

                HashSet<string> clientSideWhiteListMods = new HashSet<string>();
                if (File.Exists("mods_white_list.txt"))
                {
                    foreach(string line in File.ReadAllLines("mods_white_list.txt"))
                    {
                        clientSideWhiteListMods.Add(line);
                    }
                }

                HashSet<string> clientSideWhiteListResourcePacks = new HashSet<string>();
                if (File.Exists("resourcepacks_white_list.txt"))
                {
                    foreach (string line in File.ReadAllLines("resourcepacks_white_list.txt"))
                    {
                        clientSideWhiteListResourcePacks.Add(line);
                    }
                }

                List<Task> tasks = new List<Task>();

                // Load database stuff
                List<MCSyncFile> syncFiles = await MCSyncFile.GetMCSyncFiles();

                // Drive off of files
                List<string> handledFiles = new List<string>();

                // Mod Files
                IEnumerable<MCSyncFile> modSyncFiles = syncFiles.Where(f => f.FileType == MCSyncFile.FileTypes.mods && IsDownloadTypeValid(config.Mode, f.DownloadType));
                foreach (string file in Directory.EnumerateFiles(config.ModsDirectory, "*", SearchOption.AllDirectories))
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
                        Task updateTask = new Task($"Update mod file {strippedFile}", () => DownloadFile(syncFile.FileType, config.ModsDirectory, strippedFile, syncFile.DownloadType));
                        tasks.Add(updateTask);
                        TaskAdded?.Invoke(this, updateTask);
                    }

                    handledFiles.Add(strippedFile);
                }

                // Resource Pack Files
                IEnumerable<MCSyncFile> resourcePackSyncFiles = syncFiles.Where(f => f.FileType == MCSyncFile.FileTypes.resourcepacks && IsDownloadTypeValid(config.Mode, f.DownloadType));
                foreach (string file in Directory.EnumerateFiles(config.ResourcePackDirectory, "*", SearchOption.AllDirectories))
                {
                    string strippedFile = StripDirectory(file, MCSyncFile.FileTypes.resourcepacks);
                    byte[] fileHash = CalculateHash(file);
                    MCSyncFile syncFile = resourcePackSyncFiles.FirstOrDefault(f => f.Filename == strippedFile);
                    if (syncFile == null)
                    {
                        if (!clientSideWhiteListResourcePacks.Contains(strippedFile))
                        {
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
                        Task updateTask = new Task($"Update resource pack file {strippedFile}", () => DownloadFile(syncFile.FileType, config.ResourcePackDirectory, strippedFile, syncFile.DownloadType));
                        tasks.Add(updateTask);
                        TaskAdded?.Invoke(this, updateTask);
                    }

                    handledFiles.Add(strippedFile);
                }

                // Config
                IEnumerable<MCSyncFile> configSyncFiles = syncFiles.Where(f => f.FileType == MCSyncFile.FileTypes.config && IsDownloadTypeValid(config.Mode, f.DownloadType));
                foreach(MCSyncFile configFile in configSyncFiles)
                {
                    if (File.Exists(config.ConfigFilesDirectory + "\\" + configFile.Filename))
                    {
                        byte[] fileHash = CalculateHash(config.ConfigFilesDirectory + "\\" + configFile.Filename);
                        if (!fileHash.SequenceEqual(configFile.Checksum))
                        {
                            Task updateTask = new Task($"Update config file {configFile.Filename}", () => DownloadFile(configFile.FileType, config.ConfigFilesDirectory, configFile.Filename, configFile.DownloadType));
                            tasks.Add(updateTask);
                            TaskAdded?.Invoke(this, updateTask);
                        }

                        handledFiles.Add(configFile.Filename);
                    }
                }

                // Missing Files
                IEnumerable<MCSyncFile> missingFiles = syncFiles.Where(f => IsDownloadTypeValid(config.Mode, f.DownloadType) && !handledFiles.Contains(f.Filename));
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
                            directory = config.ModsDirectory;
                            break;
                        case MCSyncFile.FileTypes.resourcepacks:
                            directory = config.ResourcePackDirectory;
                            break;
                        case MCSyncFile.FileTypes.config:
                            directory = config.ConfigFilesDirectory;
                            break;
                    }

                    Task downloadTask = new Task($"Download {missingFile.FileType.ToString()} file {missingFile.Filename}", () => DownloadFile(missingFile.FileType, directory, missingFile.Filename, missingFile.DownloadType));
                    tasks.Add(downloadTask);
                    TaskAdded?.Invoke(this, downloadTask);
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
