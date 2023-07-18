using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;

namespace WebModels.gov
{
    [Table("784106E7-D8C8-44C5-84A4-67834F266F7D")]
    public class Law : DataObject
    {
        protected Law() : base() { }

        private long? _lawID;
        [Field("1724FBA2-A854-4C8F-98A7-32EC2B3C35D9")]
        public long? LawID
        {
            get { CheckGet(); return _lawID; }
            set { CheckSet(); _lawID = value; }
        }

        private long? _governmentID;
        [Field("DE02428E-C471-4F4C-8F69-50DA35CEDBF8")]
        [Required]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private Government _government = null;
        [Relationship("1BA7D11D-F8DB-452B-9789-68053889D4E4")]
        public Government Government
        {
            get { CheckGet(); return _government; }
        }

        private string _name;
        [Field("2F44ED9E-487B-4D98-B904-F039C601D5F2", DataSize = 30)]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value;}
        }

        private byte? _displayOrder;
        [Field("F3CF4E28-B89C-4FF8-8713-037D2810091C")]
        [Required]
        public byte? DisplayOrder
        {
            get { CheckGet(); return _displayOrder; }
            set { CheckSet(); _displayOrder = value; }
        }

        protected override void PreValidate()
        {
            base.PreValidate();

            if (IsInsert)
            {
                if (GovernmentID == null)
                {
                    DisplayOrder = byte.MaxValue;
                }
                else
                {
                    Search<Law> lawSearch = new Search<Law>(new LongSearchCondition<Law>()
                    {
                        Field = nameof(GovernmentID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = GovernmentID
                    });
                    lawSearch.SearchOrders.Add(new SearchOrder() { OrderField = nameof(DisplayOrder), OrderDirection = SearchOrder.OrderDirections.Descending });
                    Law maxLaw = lawSearch.GetReadOnly(null, new[] { nameof(DisplayOrder) });
                    if (maxLaw == null)
                    {
                        DisplayOrder = 1;
                    }
                    else
                    {
                        DisplayOrder = (byte?)(maxLaw.DisplayOrder + 1);
                    }
                }
            }
        }

        protected override bool PostSave(ITransaction transaction)
        {
            if (!IsInsert && IsFieldDirty(nameof(DisplayOrder)) && !IsSaveFlagSet(SaveFlags.SkipDisplayOrderSwapUpdate))
            {
                Search<Law> lawSearch = new Search<Law>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<Law>()
                    {
                        Field = nameof(GovernmentID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = GovernmentID
                    },
                    new LongSearchCondition<Law>()
                    {
                        Field = nameof(LawID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.NotEquals,
                        Value = LawID
                    },
                    new ByteSearchCondition<Law>()
                    {
                        Field = nameof(DisplayOrder),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = DisplayOrder
                    }));

                Law existingLaw = lawSearch.GetEditable(transaction);
                existingLaw.DisplayOrder = (byte?)GetDirtyValue(nameof(DisplayOrder));
                if (!existingLaw.Save(transaction, new List<Guid>() { SaveFlags.SkipDisplayOrderSwapUpdate }))
                {
                    Errors.AddRange(existingLaw.Errors.ToArray());
                    return false;
                }
            }

            return base.PostSave(transaction) && !Errors.Any();
        }

        protected override bool PostDelete(ITransaction transaction)
        {
            Search<Law> lawSearch = new Search<Law>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Law>()
                {
                    Field = nameof(GovernmentID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = GovernmentID
                },
                new ByteSearchCondition<Law>()
                {
                    Field = nameof(DisplayOrder),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Greater,
                    Value = DisplayOrder
                }));

            foreach(Law laterLaw in lawSearch.GetEditableReader(transaction))
            {
                laterLaw.DisplayOrder--;
                if (!laterLaw.Save(transaction, new List<Guid>() { SaveFlags.SkipDisplayOrderSwapUpdate }))
                {
                    Errors.AddRange(laterLaw.Errors.ToArray());
                    return false;
                }
            }

            return base.PostDelete(transaction);
        }

        #region Relationships
        #region gov
        private List<LawSection> _lawSections = new List<LawSection>();
        [RelationshipList("7D52FB1A-434E-404A-BCEA-FE93EABB96E4", nameof(LawSection.LawID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<LawSection> LawSections
        {
            get { CheckGet(); return _lawSections; }
        }
        #endregion
        #endregion

        public static class SaveFlags
        {
            public static readonly Guid SkipDisplayOrderSwapUpdate = new Guid("AEFD2BDC-056F-4FCF-B929-1F83E44F4272");
        }
    }
}
