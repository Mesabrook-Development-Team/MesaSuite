using System;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Validation.Conditions;

namespace WebModels.tow.Validations
{
    internal class SingleJobPerUserCondition : Condition
    {
        public override bool Evaluate(DataObject dataObject)
        {
            if (!(dataObject is TowTicket towTicket))
            {
                throw new InvalidOperationException("Can only validation against Tow Ticket data objects");
            }

            if (towTicket.Status == TowTicket.Statuses.History || towTicket.UserIDResponding == null)
            {
                return true;
            }

            Search<TowTicket> duplicateSearch = new Search<TowTicket>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.UserIDResponding),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = towTicket.UserIDResponding
                },
                new IntSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.StatusCode),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Less,
                    Value = (int)TowTicket.Statuses.History
                },
                new LongSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.TowTicketID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.NotEquals,
                    Value = towTicket.TowTicketID
                }));

            return !duplicateSearch.ExecuteExists(null);
        }
    }
}
