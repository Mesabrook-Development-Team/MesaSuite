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
    public class HandleUserInactivity : IServiceTask
    {
        public string Name => "Handle Inactive Users";

        private DateTime _nextRunTime = DateTime.Now;
        public DateTime NextRunTime => _nextRunTime;

        public bool Run()
        {
            //WarnUpcomingExpiration();
            //NotifyDOI();
            
            _nextRunTime = DateTime.Now.AddHours(1);
            return true;
        }

        private void WarnUpcomingExpiration()
        {
            Search<User> userSearch = new Search<User>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                            new DateTimeSearchCondition<User>()
                            {
                                Field = nameof(User.LastActivity),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Less,
                                Value = DateTime.Now.AddMonths(-1).AddDays(2)
                            },
                            new BooleanSearchCondition<User>()
                            {
                                Field = nameof(User.InactivityWarningServed),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = false
                            }));

            foreach (User user in userSearch.GetEditableReader())
            {
                string message = "***Mesabrook Department of Internal Affairs***\r\n**Inactivity Warning**\r\n\r\nYour Mesabrook inactivity period is about to expire! Please join Mesabrook to reset this period.\r\n\r\nAlternatively, you can reset your inactivity period here: https://www.mesabrook.com/doi/inactivity.html";
                if (DiscordHelper.SendDiscordMessage(user.DiscordID, user.Username, message))
                {
                    user.InactivityWarningServed = true;
                    user.Save();
                }
            }
        }

        private void NotifyDOI()
        {
            Search<User> userSearch = new Search<User>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new DateTimeSearchCondition<User>()
                {
                    Field = nameof(User.LastActivity),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Less,
                    Value = DateTime.Now.AddMonths(-1)
                },
                new BooleanSearchCondition<User>()
                {
                    Field = nameof(User.InactivityDOINotificationServed),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = false
                }));

            foreach(User user in userSearch.GetEditableReader())
            {
                string message = $"***Mesabrook Department of Internal Affairs***\r\n**User Inactivity Notification**\r\n\r\n*User:* {user.Username}\r\n*Last Active:* {user.LastActivity?.ToString("MM/dd/yyyy HH:mm:ss")}\r\n*Last Active Reason:* {user.LastActivityReason}\r\n\r\nThis user has been inactive for a month or longer. An investigation may be necessary for action up to and including dismissal.";
                string[] doiUsers = ConfigurationManager.AppSettings.Get("DiscordIDsUserExpired").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                bool atLeastOneSucceeded = false;
                foreach(string doiUser in doiUsers)
                {
                    atLeastOneSucceeded |= DiscordHelper.SendDiscordMessage(doiUser, $"DOIA Member {doiUser}", message);
                }

                if (atLeastOneSucceeded)
                {
                    user.InactivityDOINotificationServed = true;
                    user.Save();
                }
            }
        }

        
    }
}
