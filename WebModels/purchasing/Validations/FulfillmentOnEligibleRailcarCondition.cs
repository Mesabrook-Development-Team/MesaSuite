using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using ClussPro.ObjectBasedFramework.Validation.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModels.fleet;

namespace WebModels.purchasing.Validations
{
    public class FulfillmentOnEligibleRailcarCondition : Condition
    {
        public const string MESSAGE = "Railcar must not have a current Bill Of Lading or Fulfillment";
        public override bool Evaluate(DataObject dataObject, ITransaction transaction)
        {
            if (!(dataObject is Fulfillment fulfillment))
            {
                throw new InvalidCastException("dataObject must be a Fulfillment");
            }

            if (fulfillment.RailcarID == null)
            {
                return true;
            }

            Search<Railcar> railcarSearch = new Search<Railcar>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Railcar>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new List<object>() { r.BillOfLadingCurrent.BillOfLadingID }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Null
                },
                new LongSearchCondition<Railcar>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new List<object>() { r.FulfillmentCurrent.FulfillmentID }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Null
                },
                new LongSearchCondition<Railcar>()
                {
                    Field = nameof(Railcar.RailcarID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = fulfillment.RailcarID
                }));

            return railcarSearch.ExecuteExists(transaction);
        }
    }
}
