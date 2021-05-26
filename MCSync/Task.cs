using System;
using System.Collections.Generic;

namespace MCSync
{
    public class Task
    {
        public static HashSet<string> Errors { get; } = new HashSet<string>();
        public static HashSet<string> Informations { get; } = new HashSet<string>();

        public event EventHandler StatusUpdate;

        public string TaskDescription { get; }
        public string Status { get; private set; } = "Waiting";
        private Func<bool> _task;

        public Task(string description, Func<bool> task)
        {
            TaskDescription = description;
            _task = task;
        }

        public void Execute()
        {
            Status = "Executing";
            StatusUpdate?.Invoke(this, new EventArgs());
            if (_task())
            {
                Status = "Success";
                StatusUpdate?.Invoke(this, new EventArgs());
            }
            else
            {
                Status = "Failed";
                StatusUpdate?.Invoke(this, new EventArgs());
            }
        }
    }
}
