using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebModels.mesasys;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("system")]
    public class BlockAuditController : ApiController
    {
        private readonly List<string> FieldsToRetrieve = FieldPathUtility.CreateFieldPathsAsList<BlockAudit>(ba => new object[]
        {
            ba.BlockAuditID,
            ba.AuditTime,
            ba.BlockName,
            ba.PlayerName,
            ba.PositionX,
            ba.PositionY,
            ba.PositionZ,
            ba.AuditType
        });

        [HttpGet]
        public async Task<List<BlockAudit>> Query([FromUri]DateTime? minimumDate = null,
                                      [FromUri]DateTime? maximumDate = null,
                                      [FromUri]int? minimumX = null,
                                      [FromUri]int? minimumY = null,
                                      [FromUri]int? minimumZ = null,
                                      [FromUri]int? maximumX = null,
                                      [FromUri]int? maximumY = null,
                                      [FromUri]int? maximumZ = null,
                                      [FromUri]string blockNames = null,
                                      [FromUri]string playerNames = null,
                                      [FromUri]int skip = 0,
                                      [FromUri]int take = 500)
        {
            List<ISearchCondition> searchConditions = new List<ISearchCondition>();
            if (minimumDate != null)
            {
                searchConditions.Add(new DateTimeSearchCondition<BlockAudit>()
                {
                    Field = nameof(BlockAudit.AuditTime),
                    SearchConditionType = SearchCondition.SearchConditionTypes.GreaterEquals,
                    Value = minimumDate
                });
            }
            if (maximumDate != null)
            {
                searchConditions.Add(new DateTimeSearchCondition<BlockAudit>()
                {
                    Field = nameof(BlockAudit.AuditTime),
                    SearchConditionType = SearchCondition.SearchConditionTypes.LessEquals,
                    Value = maximumDate
                });
            }

            if (minimumX != null)
            {
                searchConditions.Add(new IntSearchCondition<BlockAudit>()
                {
                    Field = nameof(BlockAudit.PositionX),
                    SearchConditionType = SearchCondition.SearchConditionTypes.GreaterEquals,
                    Value = minimumX
                });
            }
            if (maximumX != null)
            {
                searchConditions.Add(new IntSearchCondition<BlockAudit>()
                {
                    Field = nameof(BlockAudit.PositionX),
                    SearchConditionType = SearchCondition.SearchConditionTypes.LessEquals,
                    Value = maximumX
                });
            }
            if (minimumY != null)
            {
                searchConditions.Add(new IntSearchCondition<BlockAudit>()
                {
                    Field = nameof(BlockAudit.PositionY),
                    SearchConditionType = SearchCondition.SearchConditionTypes.GreaterEquals,
                    Value = minimumY
                });
            }
            if (maximumY != null)
            {
                searchConditions.Add(new IntSearchCondition<BlockAudit>()
                {
                    Field = nameof(BlockAudit.PositionY),
                    SearchConditionType = SearchCondition.SearchConditionTypes.LessEquals,
                    Value = maximumY
                });
            }
            if (minimumZ != null)
            {
                searchConditions.Add(new IntSearchCondition<BlockAudit>()
                {
                    Field = nameof(BlockAudit.PositionZ),
                    SearchConditionType = SearchCondition.SearchConditionTypes.GreaterEquals,
                    Value = minimumZ
                });
            }
            if (maximumZ != null)
            {
                searchConditions.Add(new IntSearchCondition<BlockAudit>()
                {
                    Field = nameof(BlockAudit.PositionZ),
                    SearchConditionType = SearchCondition.SearchConditionTypes.LessEquals,
                    Value = maximumZ
                });
            }

            if (!string.IsNullOrEmpty(blockNames))
            {
                List<ISearchCondition> blockNameSearchConditions = new List<ISearchCondition>();
                foreach(string blockName in blockNames.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (blockName.Contains('%'))
                    {
                        blockNameSearchConditions.Add(new StringSearchCondition<BlockAudit>()
                        {
                            Field = nameof(BlockAudit.BlockName),
                            SearchConditionType = SearchCondition.SearchConditionTypes.Like,
                            Value = blockName.Trim()
                        });
                    }
                    else
                    {
                        blockNameSearchConditions.Add(new StringSearchCondition<BlockAudit>()
                        {
                            Field = nameof(BlockAudit.BlockName),
                            SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                            Value = blockName.Trim()
                        });
                    }
                }

                if (blockNameSearchConditions.Any())
                {
                    searchConditions.Add(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or, blockNameSearchConditions.ToArray()));
                }
            }

            if (!string.IsNullOrEmpty(playerNames))
            {
                List<ISearchCondition> playerNameSearchConditions = new List<ISearchCondition>();

                foreach (string playerName in playerNames.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (playerName.Contains('%'))
                    {
                        playerNameSearchConditions.Add(new StringSearchCondition<BlockAudit>()
                        {
                            Field = nameof(BlockAudit.PlayerName),
                            SearchConditionType = SearchCondition.SearchConditionTypes.Like,
                            Value = playerName.Trim()
                        });
                    }
                    else
                    {
                        playerNameSearchConditions.Add(new StringSearchCondition<BlockAudit>()
                        {
                            Field = nameof(BlockAudit.PlayerName),
                            SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                            Value = playerName.Trim()
                        });
                    }
                }

                if (playerNameSearchConditions.Any())
                {
                    searchConditions.Add(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or, playerNameSearchConditions.ToArray()));
                }
            }

            Search<BlockAudit> blockAuditSearch = new Search<BlockAudit>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And, searchConditions.ToArray()));
            blockAuditSearch.Skip = skip;
            blockAuditSearch.Take = take;
            blockAuditSearch.SearchOrders.Add(new SearchOrder() { OrderField = nameof(BlockAudit.AuditTime), OrderDirection = SearchOrder.OrderDirections.Descending });

            return await Task.Run(() => blockAuditSearch.GetReadOnlyReader(null, FieldsToRetrieve).ToList());
        }
    }
}
