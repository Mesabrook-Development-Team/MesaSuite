using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using ClussPro.ObjectBasedFramework.Validation.Conditions;
using System;
using WebModels.company;

namespace WebModels.purchasing.Validation
{
    public class QuotedItemInPriceManagerCondition : Condition
    {
        public override bool Evaluate(DataObject dataObject, ITransaction transaction)
        {
            if (!(dataObject is QuotationItem quotationItem))
            {
                throw new ArgumentException("DataObject must be of type QuotationItem.", nameof(dataObject));
            }

            if (quotationItem.QuotationID == null)
            {
                return true;
            }

            Quotation quotation = DataObject.GetReadOnlyByPrimaryKey<Quotation>(quotationItem.QuotationID, transaction, FieldPathUtility.CreateFieldPathsAsList<Quotation>(q => new object[]
            {
                q.CompanyIDFrom,
                q.GovernmentIDFrom
            }));

            if (quotation == null || (quotation.CompanyIDFrom == null && quotation.GovernmentIDFrom == null))
            {
                return true;
            }

            LongSearchCondition entitySearchCondition;
            if (quotation.CompanyIDFrom != null)
            {
                entitySearchCondition = new LongSearchCondition<LocationItem>()
                {
                    Field = FieldPathUtility.CreateFieldPath<LocationItem>(li => li.Location.CompanyID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = quotation.CompanyIDFrom
                };
            }
            else
            {
                entitySearchCondition = new LongSearchCondition<LocationItem>()
                {
                    Field = nameof(LocationItem.GovernmentID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = quotation.GovernmentIDFrom
                };
            }

            Search<LocationItem> itemSearch = new Search<LocationItem>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                entitySearchCondition,
                new LongSearchCondition<LocationItem>()
                {
                    Field = nameof(LocationItem.ItemID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = quotationItem.ItemID
                }));

            return itemSearch.ExecuteExists(transaction);
        }
    }
}
