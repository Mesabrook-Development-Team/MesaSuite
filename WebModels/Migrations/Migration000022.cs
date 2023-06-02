using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using System.Collections.Generic;

namespace WebModels.Migrations
{
    /// <summary>
    /// Add auth.PersonalAccessToken. Add Inactivity and Notification fields to security.User. Update auth.Client to handle devices.
    /// </summary>
    public class Migration000022 : IMigration
    {
        public int MigrationNumber => 21;

        public void Execute(ITransaction transaction)
        {
            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "auth";
            createTable.TableName = "PersonalAccessToken";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "PersonalAccessTokenID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "UserID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 30) },
                { "Token", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "Expiration", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "CanRefreshInactivity", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } },
                { "CanPerformNetworkPrinting", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } }
            };
            createTable.Execute(transaction);

            createTable.TableName = "UserClient";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "UserClientID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "UserID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "ClientID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "AuthorizationTime", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "DeviceCode";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "DeviceCodeID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "ClientID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "DeviceCodeString", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 16) },
                { "UserCode", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 5) },
                { "LastPing", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "Status", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "CodeID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) }
            };
            createTable.Execute(transaction);

            IAlterTable alter = SQLProviderFactory.GetAlterTableQuery();
            alter.Schema = "auth";
            alter.Table = "DeviceCode";
            alter.AddForeignKey("FKDeviceCode_Client_ClientID", "ClientID", "auth", "Client", "ClientID", transaction);
            alter.AddForeignKey("FKDeviceCode_Code_CodeID", "CodeID", "auth", "Code", "CodeID", transaction);

            alter.Table = "PersonalAccessToken";
            alter.AddForeignKey("FKPersonalAccessToken_User_UserID", "UserID", "security", "User", "UserID", transaction);

            alter.Table = "Token";
            alter.AddColumn("GrantTime", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7), transaction);

            alter.Schema = "security";
            alter.Table = "User";
            alter.AddColumn("LastActivity", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7), transaction);
            alter.AddColumn("LastActivityReason", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 1000), transaction);
            alter.AddColumn("InactivityWarningServed", new FieldSpecification(FieldSpecification.FieldTypes.Bit), transaction);
            alter.AddColumn("DiscordID", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 18), transaction);

            alter.Schema = "auth";
            alter.Table = "Client";
            alter.AddColumn("Type", new FieldSpecification(FieldSpecification.FieldTypes.Int), transaction);
            alter.AddColumn("ClientName", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50), transaction);
            alter.AddColumn("UserID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt), transaction);
            alter.AddForeignKey("FKClient_User_UserID", "UserID", "security", "User", "UserID", transaction);
        }
    }
}
