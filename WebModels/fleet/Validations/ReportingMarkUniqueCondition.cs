using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Validation.Conditions;

namespace WebModels.fleet.Validations
{
    public class ReportingMarkUniqueCondition : Condition
    {
        public override bool Evaluate(DataObject dataObject, ITransaction transaction)
        {
            if (!(dataObject is Railcar railcar) && !(dataObject is Locomotive locomotive))
            {
                throw new ArgumentException("dataObject must be either a Railcar or Locomotive", "dataObject");
            }
            railcar = dataObject is Railcar ? (Railcar)dataObject : null;
            locomotive = dataObject is Locomotive ? (Locomotive)dataObject : null;

            SearchConditionGroup railcarSearchCondition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new StringSearchCondition<Railcar>()
                {
                    Field = nameof(Railcar.ReportingMark),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = railcar?.ReportingMark ?? locomotive?.ReportingMark
                },
                new IntSearchCondition<Railcar>()
                {
                    Field = nameof(Railcar.ReportingNumber),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = railcar?.ReportingNumber ?? locomotive?.ReportingNumber
                });

            if (railcar?.RailcarID != null)
            {
                railcarSearchCondition.SearchConditions.Add(new LongSearchCondition<Railcar>()
                {
                    Field = nameof(Railcar.RailcarID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.NotEquals,
                    Value = railcar.RailcarID
                });
            }

            Search<Railcar> duplicateRailcarSearch = new Search<Railcar>(railcarSearchCondition);
            if (duplicateRailcarSearch.ExecuteExists(null))
            {
                return false;
            }

            SearchConditionGroup locomotiveSearchCondition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new StringSearchCondition<Locomotive>()
                {
                    Field = nameof(Locomotive.ReportingMark),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = railcar?.ReportingMark ?? locomotive?.ReportingMark
                },
                new IntSearchCondition<Locomotive>()
                {
                    Field = nameof(Locomotive.ReportingNumber),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = railcar?.ReportingNumber ?? locomotive?.ReportingNumber
                });

            if (locomotive?.LocomotiveID != null)
            {
                locomotiveSearchCondition.SearchConditions.Add(new LongSearchCondition<Locomotive>()
                {
                    Field = nameof(Locomotive.LocomotiveID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.NotEquals,
                    Value = locomotive.LocomotiveID
                });
            }

            Search<Locomotive> duplicateLocomotiveSearch = new Search<Locomotive>(locomotiveSearchCondition);
            if (duplicateLocomotiveSearch.ExecuteExists(null))
            {
                return false;
            }

            return true;    
        }
    }
}
