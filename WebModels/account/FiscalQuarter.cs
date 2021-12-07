using System;
using System.Collections.Generic;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

namespace WebModels.account
{
    [Table("1B9110F3-36BA-46B5-B568-134EEA7C6428")]
    public class FiscalQuarter : DataObject
    {
        protected FiscalQuarter() : base() { }

        private long? _fiscalQuarterID = null;
        [Field("0738106E-8697-4E54-914F-76E9FC868855")]
        public long? FiscalQuarterID 
        {
            get { CheckGet(); return _fiscalQuarterID; }
            set { CheckSet(); _fiscalQuarterID = value; }
        }

        private long? _accountID;
        [Field("D167B434-0098-4950-90C6-07631756FFC7")]
        public long? AccountID
        {
            get { CheckGet(); return _accountID; }
            set { CheckSet(); _accountID = value; }
        }

        private Account _account;
        [Relationship("6B4F0BE7-9E9D-4F1E-8BC7-3A087A578987")]
        public Account Account
        {
            get { CheckGet(); return _account; }
        }

        private byte? _quarter;
        [Field("57256262-B280-4A39-AE4B-5756FC927DDE")]
        public byte? Quarter
        {
            get { CheckGet(); return _quarter; }
            set { CheckSet(); _quarter = value; }
        }

        private short? _year;
        [Field("2DB710A6-1E5B-4AE3-84AA-8A9E8567F75A")]
        public short? Year
        {
            get { CheckGet(); return _year; }
            set { CheckSet(); _year = value; }
        }

        private DateTime? _startDate;
        [Field("3453399F-A1E2-4C99-94F9-5C48804103D7", DataSize = 7)]
        public DateTime? StartDate
        {
            get { CheckGet(); return _startDate; }
            set { CheckSet(); _startDate = value; }
        }

        private DateTime? _endDate;
        [Field("E373F1AB-5BA2-486E-BFCB-3F2781616723", DataSize = 7)]
        public DateTime? EndDate
        {
            get { CheckGet(); return _endDate; }
            set { CheckSet(); _endDate = value; }
        }

        private decimal? _startingBalance;
        [Field("0DAF1032-C949-469F-8393-8D9C8CB25E6B", DataSize = 11, DataScale = 2)]
        public decimal? StartingBalance
        {
            get { CheckGet(); return _startingBalance; }
            set { CheckSet(); _startingBalance = value; }
        }

        private decimal? _endingBalance;
        [Field("89064BD4-4571-4793-B9DC-66D5510C0819", DataSize = 11, DataScale = 2)]
        public decimal? EndingBalance
        {
            get { CheckGet(); return _endingBalance; }
            set { CheckSet(); _endingBalance = value; }
        }

        #region Relationships
        #region account
        private List<Transaction> _transactions = new List<Transaction>();
        [RelationshipList("D96B7FA3-E03C-46F2-B0AD-020A52FFD793", "FiscalQuarterID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<Transaction> Transactions
        {
            get { CheckGet(); return _transactions; }
        }
        #endregion
        #endregion

        public static FiscalQuarter FindOrCreate(long accountID, DateTime time, ITransaction transaction = null, IEnumerable<string> additionalFields = null)
        {
            byte quarter = GetQuarterForDate(time);

            Search<FiscalQuarter> fiscalQuarterSearch = new Search<FiscalQuarter>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<FiscalQuarter>()
                {
                    Field = "AccountID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = accountID
                },
                new ByteSearchCondition<FiscalQuarter>()
                {
                    Field = "Quarter",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = quarter
                },
                new ShortSearchCondition<FiscalQuarter>()
                {
                    Field = "Year",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = (short)time.Year
                }));

            FiscalQuarter result = fiscalQuarterSearch.GetEditable(transaction, additionalFields);
            if (result == null)
            {
                // We need a new one, but in order to get starting balance, we need to find the previous ending balance
                byte previousQuarterNumber = GetQuarterForDate(time);
                previousQuarterNumber--;
                bool isPreviousYear = false;
                if (previousQuarterNumber == 0)
                {
                    previousQuarterNumber = 4;
                    isPreviousYear = true;
                }

                Search<FiscalQuarter> previousQuarterSearch = new Search<FiscalQuarter>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<FiscalQuarter>()
                    {
                        Field = "AccountID",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = accountID
                    },
                    new ByteSearchCondition<FiscalQuarter>()
                    {
                        Field = "Quarter",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = previousQuarterNumber
                    },
                    new ShortSearchCondition<FiscalQuarter>()
                    {
                        Field = "Year",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = isPreviousYear ? (short)(time.Year - 1) : (short)time.Year
                    }));

                FiscalQuarter previousQuarter = previousQuarterSearch.GetReadOnly(transaction, new string[] { "EndingBalance" });
                decimal? previousBalance = previousQuarter?.EndingBalance;

                result = DataObjectFactory.Create<FiscalQuarter>();
                result.AccountID = accountID;
                result.Quarter = GetQuarterForDate(time);
                result.Year = (short)time.Year;
                (int, int) monthRange = GetMonthRangeForQuarter(result.Quarter.Value);
                result.StartDate = new DateTime(time.Year, monthRange.Item1, 1);
                result.EndDate = new DateTime(time.Year, monthRange.Item2, 1).AddMonths(1).AddSeconds(-1);
                result.StartingBalance = previousBalance ?? 0M;

                if (!result.Save(transaction))
                {
                    throw new Exception("Could not create new Fiscal Quarter:\r\n\r\n" + result.Errors.ToString());
                }

                result = DataObject.GetEditableByPrimaryKey<FiscalQuarter>(result.FiscalQuarterID, transaction, additionalFields);
            }

            return result;
        }

        public static byte GetQuarterForDate(DateTime date)
        {
            return Convert.ToByte(((date.Month - 1) / 3) + 1);
        }

        public static (int, int) GetMonthRangeForQuarter(byte quarter)
        {
            return (quarter * 3 - 2, quarter * 3);
        }
    }
}
