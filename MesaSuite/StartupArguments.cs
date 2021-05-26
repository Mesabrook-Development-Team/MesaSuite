using System;
using System.Collections.Generic;
using System.Text;

namespace MesaSuite
{
    public class StartupArguments
    {
        public static string FolderToDelete { get; set; }
        public static int UpdaterProcessID { get; set; } = -1;
        public static string Run { get; set; }

        public static Dictionary<string, List<string>> ArgumentsByPrefix = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        public static void SetupArguments(string[] args)
        {
            StringBuilder argCombiner = new StringBuilder();
            foreach(string arg in args)
            {
                if (argCombiner.Length > 0)
                {
                    argCombiner.Append(" ");
                }

                argCombiner.Append(arg);
            }

            string[] betterArgs = argCombiner.ToString().Split('-');
            for (int i = 1; i < betterArgs.Length; i++)
            {
                string arg = betterArgs[i];
                string[] subargs = arg.Split(' ');
                if (arg.StartsWith("folder"))
                {
                    if (subargs.Length < 2)
                    {
                        continue;
                    }

                    FolderToDelete = subargs[1];
                }
                else if (arg.StartsWith("processID"))
                {
                    if (subargs.Length < 2 || !int.TryParse(subargs[1], out int processID))
                    {
                        continue;
                    }

                    UpdaterProcessID = processID;
                }
                else if (arg.StartsWith("run"))
                {
                    if (subargs.Length < 2)
                    {
                        continue;
                    }

                    Run = subargs[1];
                }
                else if (arg.Contains("."))
                {
                    string prefix = arg.Substring(0, arg.IndexOf('.'));

                    if (!ArgumentsByPrefix.ContainsKey(prefix))
                    {
                        ArgumentsByPrefix[prefix] = new List<string>();
                    }

                    ArgumentsByPrefix[prefix].Add(arg);
                }
            }
        }

        public static string[] GetArgsForApp(string appName)
        {
            string[] args = null;
            if (ArgumentsByPrefix.ContainsKey(appName))
            {
                args = ArgumentsByPrefix[appName].ToArray();
            }

            return args;
        }
    }
}
