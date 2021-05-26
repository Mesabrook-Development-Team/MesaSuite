using System;
using System.Collections.Generic;
using System.Linq;

namespace MCSync
{
    public class NonInteractiveRun
    {
        public bool IsRunning { get; private set; }
        public void Run()
        {
            IsRunning = true;

            //Updater.UpdaterResults updaterResults = Updater.Run();
            //if (updaterResults.HasUpdates)
            //{
            //    DisplayUpdates(updaterResults.UpdatesAvailable);
            //    IsRunning = false;
            //    return;
            //}

            Syncer syncer = new Syncer();
            syncer.TaskAdded += Syncer_TaskAdded;
            syncer.SyncComplete += Syncer_SyncComplete;
            syncer.BeginSync();
        }

        //private void DisplayUpdates(List<Updater.MCSyncVersion> versions)
        //{
        //    Console.ForegroundColor = ConsoleColor.DarkYellow;
        //    Console.WriteLine("Update(s) for MC Sync are available!");
        //    Console.WriteLine();

        //    Console.ForegroundColor = ConsoleColor.White;
        //    foreach(Updater.MCSyncVersion version in versions)
        //    {
        //        Console.WriteLine($"Version: {version.VersionString}");
        //        Console.WriteLine($"Released: {version.Valid.ToString("MM/dd/yyyy HH:mm")}");
        //        Console.WriteLine($"Release Notes:\r\n{version.ReleaseNotes}");
        //        Console.WriteLine();
        //    }

        //    Console.ForegroundColor = ConsoleColor.DarkYellow;
        //    Console.WriteLine("NOTE: You MUST update MCSync.  Synchronization will not be applied until MCSync has been updated.");
        //    Console.WriteLine();
        //    Console.ForegroundColor = ConsoleColor.White;

        //    Console.Write("Would you like to download and install updates now (y/n)?");
        //    string answer = Console.ReadLine();

        //    if (!answer.Equals("y", StringComparison.OrdinalIgnoreCase))
        //    {
        //        return;
        //    }

        //    Updater.DownloadAndStartUpdate(versions.First().VersionString);
        //}

        private void Syncer_SyncComplete(object sender, EventArgs e)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            foreach(string error in Task.Errors)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
            }

            foreach(string information in Task.Informations)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(information);
            }

            Console.ForegroundColor = currentColor;
            Console.WriteLine("Sync complete!");

            IsRunning = false;
        }

        private void Syncer_TaskAdded(object sender, Task e)
        {
            e.StatusUpdate += Task_StatusUpdate;
        }

        private void Task_StatusUpdate(object sender, EventArgs e)
        {
            Task task = (Task)sender;
            Console.WriteLine($"{task.TaskDescription}...{task.Status}");
        }
    }
}
