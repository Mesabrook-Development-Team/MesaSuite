namespace Updater
{
    public class StartupArguments
    {
        public static string VersionToDownload { get; set; }
        public static string FolderToDelete { get; set; }
        public static int MCSyncProcessID { get; set; } = -1;

        public static void SetupArguments(string[] args)
        {
            int versionIndex = -1;
            int folderIndex = -1;
            int processIDIndex = -1;

            for (int i = 0; i < args.Length - 1; i++)
            {
                string arg = args[i];
                if (arg.StartsWith("-version"))
                {
                    versionIndex = i;
                }
                else if (arg.StartsWith("-folder"))
                {
                    folderIndex = i;
                }
                else if (arg.StartsWith("-processID"))
                {
                    processIDIndex = i;
                }
            }

            if (versionIndex != -1)
            {
                VersionToDownload = args[versionIndex + 1];
            }

            if (folderIndex != -1)
            {
                FolderToDelete = args[folderIndex + 1];
            }

            if (processIDIndex != -1 && int.TryParse(args[processIDIndex + 1], out int processID))
            {
                MCSyncProcessID = processID;
            }
        }
    }
}
