using System;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.security;

namespace MesaService.ServiceTasks
{
    public class WarnUsersOfInactivity : IServiceTask
    {
        public string Name => "Warn Users of Impending Inactivity Expiration";

        private DateTime _nextRunTime = DateTime.Now;
        public DateTime NextRunTime => _nextRunTime;

        public bool Run()
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

            foreach(User user in userSearch.GetEditableReader())
            {
                // TODO: Issue warning via Discord here
                string message = "Your Mesabrook inactivity period is about to expire! Please join Mesabrook to reset this period.\r\n\r\nAlternatively, you can reset your inactivity period here: https://www.mesabrook.com/ResetInactivity";
                user.InactivityWarningServed = true;
                user.Save();
            }

            _nextRunTime = DateTime.Now.AddHours(1);
            return true;
        }
    }
}
