using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MesaService
{
    public partial class MainService : ServiceBase
    {
        private CancellationTokenSource _cancellationTokenSource;
        Task threadTask;
        public MainService()
        {
            InitializeComponent();
        }

#if DEBUG
        public void Start(string[] args)
        {
            OnStart(args);
        }
#endif

        protected override void OnStart(string[] args)
        {
            EventLogEntry("Starting MesaService...");
            _cancellationTokenSource = new CancellationTokenSource();
            threadTask = Task.Run(MesaServiceThread, _cancellationTokenSource.Token);
        }

        protected override void OnStop()
        {
            _cancellationTokenSource.Cancel();
        }

        private void MesaServiceThread()
        {
            while(true)
            {
                
                _cancellationTokenSource.Token.WaitHandle.WaitOne(60_000);
                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    break;
                }
            }
        }

        public void WaitForFinish()
        {
            threadTask.Wait();
        }

        private void EventLogEntry(string entry)
        {
            try
            {
                if (!EventLog.SourceExists("MesaService"))
                {
                    EventLog.CreateEventSource("MesaService", "Application");
                }
                EventLog.WriteEntry("MesaService", entry, EventLogEntryType.Information);
            }
            catch
            {
                Console.WriteLine("WARNING: Could not write to Event Log: " + entry);
            }
        }
    }
}
