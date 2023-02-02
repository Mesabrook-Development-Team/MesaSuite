using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Validation;
using ClussPro.ObjectBasedFramework.Validation.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.fleet.Validations
{
    public class TrainValidationDefinition : IValidationDefinition
    {
        public string Schema => "fleet";

        public string Object => nameof(Train);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("DB169A6E-13F7-4BF6-B1C4-9B47D19EB2A8"),
                    Message = "Only one Train Symbol may be active at a time",
                    Field = nameof(Train.TrainSymbolID),
                    Condition = new TrainSymbolActiveCondition()
                };
            }
        }

        public class TrainSymbolActiveCondition : Condition
        {
            public override bool Evaluate(DataObject dataObject)
            {
                if (!(dataObject is Train train))
                {
                    throw new ArgumentException("dataObject must be of type Train", nameof(dataObject));
                }

                if (train.TrainSymbolID == null)
                {
                    return true;
                }

                SearchConditionGroup searchConditionGroup = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new IntSearchCondition<Train>()
                    {
                        Field = nameof(Train.Status),
                        SearchConditionType = SearchCondition.SearchConditionTypes.NotEquals,
                        Value = (int)Train.Statuses.Complete
                    },
                    new LongSearchCondition<Train>()
                    {
                        Field = nameof(Train.TrainSymbolID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = train.TrainSymbolID
                    });

                if (train.TrainID != null)
                {
                    searchConditionGroup.SearchConditions.Add(new LongSearchCondition<Train>()
                    {
                        Field = nameof(Train.TrainID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.NotEquals,
                        Value = train.TrainID
                    });
                }

                Search<Train> existsSearch = new Search<Train>(searchConditionGroup);
                return !existsSearch.ExecuteExists(null);
            }
        }
    }
}
