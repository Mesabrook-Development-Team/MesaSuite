using System;
using System.Configuration;
using System.IO;
using System.Net;
using ClussPro.ObjectBasedFramework.DataSearch;
using MesaService.Utility;
using Newtonsoft.Json;
using WebModels.security;

namespace MesaService.ServiceTasks
{
    public class DiscordHeartbeatTask : IServiceTask
    {
        public string Name => "Send Message To Gamearoo";

        private DateTime _nextRunTime = DateTime.Now;
        public DateTime NextRunTime => _nextRunTime;

        public bool Run()
        {
            DiscordHelper.SendDiscordMessage(ConfigurationManager.AppSettings.Get("GamearooUserID"), "Gamearoo", "Hello Gamearoo This is a message from MesaSuite sent to the bot's api. \n I am just letting you know i ran and if you see this message from the bot it works <:green:1123707359232020520> .");

            _nextRunTime = DateTime.Now.AddHours(23);
            return true;
        }
    }
}
