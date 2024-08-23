using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.Migrations
{
    public class Migration000028 : IMigration
    {
        public int MigrationNumber => 28;

        public void Execute(ITransaction transaction)
        {
            CreateDiscordTables(transaction);
            CreateNotificationTables(transaction);
            CreateTaskTables(transaction);
        }

        private void CreateDiscordTables(ITransaction transaction)
        {
            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "mesasys";
            createTable.TableName = "DiscordEmbed";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "DiscordEmbedID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "Description", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) },
                { "Color", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "URL", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "AuthorName", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "AuthorURL", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "AuthorIconURL", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "ThumbnailURL", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "ImageURL", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "FooterText", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) },
                { "FooterIconURL", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "Title", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "DiscordEmbedField";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "DiscordEmbedFieldID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "DiscordEmbedID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "Value", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 1000) },
                { "IsInline", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } }
            };
            createTable.Execute(transaction);
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "mesasys";
            alterTable.Table = "DiscordEmbedField";
            alterTable.AddForeignKey("FKDiscordEmbedField_DiscordEmbed_DiscordEmbedID", "DiscordEmbedID", "mesasys", "DiscordEmbed", "DiscordEmbedID", transaction);

            createTable.TableName = "OutboundDiscord";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "OutboundDiscordID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "DMUserID", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 20) },
                { "ChannelID", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 20) },
                { "PingRoleID", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 20) },
                { "PingUserID", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 20) },
                { "Content", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 1000) },
                { "DiscordEmbedID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) }
            };
            createTable.Execute(transaction);
            alterTable.Table = "OutboundDiscord";
            alterTable.AddForeignKey("FKOutboundDiscord_DiscordEmbed_DiscordEmbedID", "DiscordEmbedID", "mesasys", "DiscordEmbed", "DiscordEmbedID", transaction);
        }

        private void CreateNotificationTables(ITransaction transaction)
        {
            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "mesasys";
            createTable.TableName = "NotificationEvent";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "NotificationEventID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "ScopeType", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "Category", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "ScopePermissions", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, -1) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "IsPublished", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } },
                { "Parameters", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, -1) },
                { "DefaultNotificationText", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 1000) },
                { "UserIDOwner", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "UserSecret", new FieldSpecification(FieldSpecification.FieldTypes.UniqueIdentifier) },
                { "SystemID", new FieldSpecification(FieldSpecification.FieldTypes.UniqueIdentifier) },
                { "SystemHash", new FieldSpecification(FieldSpecification.FieldTypes.Binary) }
            };
            createTable.Execute(transaction);
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "mesasys";
            alterTable.Table = "NotificationEvent";
            alterTable.AddForeignKey("FKNotificationEvent_User_UserIDOwner", "UserIDOwner", "security", "User", "UserID", transaction);

            createTable.TableName = "NotificationEventEntity";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "NotificationEventEntityID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "NotificationEventID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocationID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) }
            };
            createTable.Execute(transaction);
            alterTable.Table = "NotificationEventEntity";
            alterTable.AddForeignKey("FKNotificationEventEntity_NotificationEvent_NotificationEventID", "NotificationEventID", "mesasys", "NotificationEvent", "NotificationEventID", transaction);
            alterTable.AddForeignKey("FKNotificationEventEntity_Company_CompanyID", "CompanyID", "company", "Company", "CompanyID", transaction);
            alterTable.AddForeignKey("FKNotificationEventEntity_Location_LocationID", "LocationID", "company", "Location", "LocationID", transaction);
            alterTable.AddForeignKey("FKNotificationEventEntity_Government_GovernmentID", "GovernmentID", "gov", "Government", "GovernmentID", transaction);

            createTable.TableName = "NotificationSubscriber";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "NotificationSubscriberID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "NotificationEventID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "UserID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "NotificationText", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 1000) },
                { "UseDiscord", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } },
                { "DiscordDMUserID", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 20) },
                { "DiscordChannelID", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 20) },
                { "DiscordPingRoleID", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 20) },
                { "DiscordPingUserID", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 20) },
                { "DiscordContent", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 1000) },
                { "DiscordEmbedID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "UseEmail", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } },
                { "EmailFromName", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) },
                { "EmailFromEmail", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "EmailTo", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "EmailSubject", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "EmailBody", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 4000) },
                { "IsReportableInGame", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } },
                { "MarkReadAfterDelivery", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } }
            };
            createTable.Execute(transaction);
            alterTable.Table = "NotificationSubscriber";

            alterTable.AddForeignKey("FKNotificationSubscriber_DiscordEmbed_DiscordEmbedID", "DiscordEmbedID", "mesasys", "DiscordEmbed", "DiscordEmbedID", transaction);
            alterTable.AddForeignKey("FKNotificationSubscriber_NotificationEvent_NotificationEventID", "NotificationEventID", "mesasys", "NotificationEvent", "NotificationEventID", transaction);
            alterTable.AddForeignKey("FKNotificationSubscriber_User_UserID", "UserID", "security", "User", "UserID", transaction);

            createTable.TableName = "NotificationSubscriberEntity";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "NotificationSubscriberEntityID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "NotificationSubscriberID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocationID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) }
            };
            createTable.Execute(transaction);
            alterTable.Table = "NotificationSubscriberEntity";
            alterTable.AddForeignKey("FKNotificationSubscriberEntity_NotificationSubscriber_NotificationSubscriberID", "NotificationSubscriberID", "mesasys", "NotificationSubscriber", "NotificationSubscriberID", transaction);
            alterTable.AddForeignKey("FKNotificationSubscriberEntity_Company_CompanyID", "CompanyID", "company", "Company", "CompanyID", transaction);
            alterTable.AddForeignKey("FKNotificationSubscriberEntity_Location_LocationID", "LocationID", "company", "Location", "LocationID", transaction);
            alterTable.AddForeignKey("FKNotificationSubscriberEntity_Government_GovernmentID", "GovernmentID", "gov", "Government", "GovernmentID", transaction);

            createTable.TableName = "Notification";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "NotificationID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "NotificationSubscriberID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "NotificationTime", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "IsRead", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } },
                { "IsReportableInGame", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } },
                { "Message", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 1000) }
            };
            createTable.Execute(transaction);
            alterTable.Table = "Notification";
            alterTable.AddForeignKey("FKNotification_NotificationSubscriber_NotificationSubscriberID", "NotificationSubscriberID", "mesasys", "NotificationSubscriber", "NotificationSubscriberID", transaction);
        }

        private void CreateTaskTables(ITransaction transaction)
        {
            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "mesasys";
            createTable.TableName = "TaskEvent";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "TaskEventID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "SystemID", new FieldSpecification(FieldSpecification.FieldTypes.UniqueIdentifier) },
                { "SystemHash", new FieldSpecification(FieldSpecification.FieldTypes.Binary) },
                { "ScopeType", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "ScopePermissions", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, -1) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "TaskSubscriber";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "TaskSubscriberID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "TaskEventID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "UserID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) }
            };
            createTable.Execute(transaction);
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "mesasys";
            alterTable.Table = "TaskSubscriber";
            alterTable.AddForeignKey("FKTaskSubscriber_TaskEvent_TaskEventID", "TaskEventID", "mesasys", "TaskEvent", "TaskEventID", transaction);
            alterTable.AddForeignKey("FKTaskSubscriber_User_UserID", "UserID", "security", "User", "UserID", transaction);
        }
    }
}
