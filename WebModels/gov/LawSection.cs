using System;
using System.Collections.Generic;
using System.Linq;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

namespace WebModels.gov
{
    [Table("4F63CD0E-BA2D-4C64-B0C1-F3EC354E2CFE")]
    public class LawSection : DataObject
    {
        protected LawSection() : base() { }

        private long? _lawSectionID;
        [Field("CD46FED7-C13B-424B-8F7F-39E958E4C64E")]
        public long? LawSectionID
        {
            get { CheckGet(); return _lawSectionID; }
            set { CheckSet(); _lawSectionID = value; }
        }

        private long? _lawID;
        [Field("8BF34F8F-7290-4529-A381-552025DCBE4B")]
        public long? LawID
        {
            get { CheckGet(); return _lawID; }
            set { CheckSet(); _lawID = value; }
        }

        private Law _law = null;
        [Relationship("8A2A7239-F1D4-42D1-B848-87AC427DBEA7")]
        public Law Law
        {
            get { CheckGet(); return _law; }
        }

        private string _title;
        [Field("4E1A6F80-E847-4DDF-B669-3E8470D5E3C8", DataSize = 30)]
        public string Title
        {
            get { CheckGet(); return _title; }
            set { CheckSet(); _title = value;}
        }

        private string _detail;
        [Field("CE5AF076-3AE7-4B93-830E-4AE787666946", DataSize = -1)]
        public string Detail
        {
            get { CheckGet(); return _detail; }
            set { CheckSet(); _detail = value; }
        }

        private byte? _displayOrder;
        [Field("511B6A36-EBE3-4B62-9575-D5EE49CC6E95")]
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
                if (LawID == null)
                {
                    DisplayOrder = byte.MaxValue;
                }
                else
                {
                    Search<LawSection> lawSectionSearch = new Search<LawSection>(new LongSearchCondition<LawSection>()
                    {
                        Field = nameof(LawID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = LawID
                    });
                    lawSectionSearch.SearchOrders.Add(new SearchOrder() { OrderField = nameof(DisplayOrder), OrderDirection = SearchOrder.OrderDirections.Descending });
                    LawSection maxLawSection = lawSectionSearch.GetReadOnly(null, new[] { nameof(DisplayOrder) });
                    if (maxLawSection == null)
                    {
                        DisplayOrder = 1;
                    }
                    else
                    {
                        DisplayOrder = (byte?)(maxLawSection.DisplayOrder + 1);
                    }
                }
            }
        }

       protected override bool PostSave(ITransaction transaction)
        {
            if (!IsInsert && IsFieldDirty(nameof(DisplayOrder)) && !IsSaveFlagSet(SaveFlags.SkipDisplayOrderSwapUpdate))
            {
                Search<LawSection> lawSectionSearch = new Search<LawSection>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<LawSection>()
                    {
                        Field = nameof(LawID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = LawID
                    },
                    new LongSearchCondition<LawSection>()
                    {
                        Field = nameof(LawSectionID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.NotEquals,
                        Value = LawSectionID
                    },
                    new ByteSearchCondition<LawSection>()
                    {
                        Field = nameof(DisplayOrder),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = DisplayOrder
                    }));

                LawSection existingLawSection = lawSectionSearch.GetEditable(transaction);
                existingLawSection.DisplayOrder = (byte?)GetDirtyValue(nameof(DisplayOrder));
                if (!existingLawSection.Save(transaction, new List<Guid>() { SaveFlags.SkipDisplayOrderSwapUpdate }))
                {
                    Errors.AddRange(existingLawSection.Errors.ToArray());
                    return false;
                }
            }

            return base.PostSave(transaction) && !Errors.Any();
        }

        protected override bool PostDelete(ITransaction transaction)
        {
            Search<LawSection> lawSectionSearch = new Search<LawSection>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<LawSection>()
                {
                    Field = nameof(LawID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = LawID
                },
                new ByteSearchCondition<LawSection>()
                {
                    Field = nameof(DisplayOrder),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Greater,
                    Value = DisplayOrder
                }));

            foreach(LawSection laterLawSection in lawSectionSearch.GetEditableReader(transaction))
            {
                laterLawSection.DisplayOrder--;
                if (!laterLawSection.Save(transaction, new List<Guid>() { SaveFlags.SkipDisplayOrderSwapUpdate }))
                {
                    Errors.AddRange(laterLawSection.Errors.ToArray());
                    return false;
                }
            }

            return base.PostDelete(transaction);
        }

        public static class SaveFlags
        {
            public static readonly Guid SkipDisplayOrderSwapUpdate = new Guid("192589ED-8767-4FEA-8532-776A3A95A20F");
        }
    }
}
