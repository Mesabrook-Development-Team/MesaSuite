namespace Updater
{
    public class StartupArguments
    {
        public static string VersionToDownload { get; set; }
        public static int MCSyncProcessID { get; set; } = -1;
        public static bool Uninstall { get; set; }
        public static bool UninstallQuietly { get; set; }

        public static void SetupArguments(string[] args)
        {
            int versionIndex = -1;
            int processIDIndex = -1;

            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                if (arg.StartsWith("-version"))
                {
                    versionIndex = i;
                }
                else if (arg.StartsWith("-processID"))
                {
                    processIDIndex = i;
                }
                else if (arg.Equals("-uninstall"))
                {
                    Uninstall = true;
                }
                else if (arg.Equals("-uninstallquiet"))
                {
                    UninstallQuietly = true;
                }
            }

            if (versionIndex != -1)
            {
                VersionToDownload = args[versionIndex + 1];
            }

            if (processIDIndex != -1 && int.TryParse(args[processIDIndex + 1], out int processID))
            {
                MCSyncProcessID = processID;
            }
        }
    }
}
