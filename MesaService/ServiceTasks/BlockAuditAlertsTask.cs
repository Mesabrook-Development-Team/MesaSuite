using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using MesaService.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.mesasys;

namespace MesaService.ServiceTasks
{
    public class BlockAuditAlertsTask : IServiceTask
    {
        private const string FORMAT = "***Mesabrook Department of State Security***\r\n" +
            "**Restricted Block Audit Notification**\r\n\r\n" +
            "User {0} has {1} a(n) {2} at {3}, {4}, {5}. This is a restricted action.\r\n" +
            "[Dynmap Link](http://map.mesabrook.com/#world;flat;{3},{4},{5};6)";

        private static readonly List<string> _alertFieldsToRetrieve = FieldPathUtility.CreateFieldPathsAsList<BlockAuditAlert>(baa => new object[]
        {
            baa.BlockAudit.PlayerName,
            baa.BlockAudit.AuditType,
            baa.BlockAudit.BlockName,
            baa.BlockAudit.PositionX,
            baa.BlockAudit.PositionY,
            baa.BlockAudit.PositionZ
        });
        public string Name => "Alert Marshals Regarding Block Audits";

        private DateTime _nextRunTime = DateTime.Now;
        public DateTime NextRunTime => _nextRunTime;

        public bool Run()
        {
            _nextRunTime = DateTime.Now.AddMinutes(10);

            Search<BlockAuditAlert> alerts = new Search<BlockAuditAlert>(new BooleanSearchCondition<BlockAuditAlert>()
            {
                Field = nameof(BlockAuditAlert.IsAcknowledged),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = false
            });

            if (alerts.ExecuteExists(null))
            {
                BlockAuditAlertConfig config = BlockAuditAlertConfig.GetOrCreate(new[] { nameof(BlockAuditAlertConfig.DiscordIDs) }).Result;
                if (string.IsNullOrEmpty(config.DiscordIDs))
                {
                    return true;
                }

                List<BlockAuditAlert> alertsToSend = alerts.GetEditableReader(readOnlyFields: _alertFieldsToRetrieve).ToList();

                string[] discordIDs = config.DiscordIDs.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string discordID in discordIDs)
                {
                    foreach (BlockAuditAlert alert in alertsToSend)
                    {
                        string auditText = "[Unknown]";
                        switch(alert.BlockAudit.AuditType)
                        {
                            case BlockAudit.AuditTypes.Break:
                                auditText = "broken";
                                break;
                            case BlockAudit.AuditTypes.Place:
                                auditText = "placed";
                                break;
                            case BlockAudit.AuditTypes.Use:
                                auditText = "used";
                                break;
                        }

                        if (DiscordHelper.SendDiscordMessage(discordID, discordID, string.Format(FORMAT,
                            alert.BlockAudit.PlayerName,
                            auditText,
                            alert.BlockAudit.BlockName,
                            alert.BlockAudit.PositionX,
                            alert.BlockAudit.PositionY,
                            alert.BlockAudit.PositionZ)))
                        {
                            if (!alert.IsAcknowledged)
                            { 
                                alert.IsAcknowledged = true;
                                alert.Save();
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}
