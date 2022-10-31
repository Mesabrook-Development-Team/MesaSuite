using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GovernmentPortal.Extensions;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Utility;

namespace GovernmentPortal.WireTransfers
{
    internal class WireTransferHistoryContext : ExplorerContext<WireTransferHistory>
    {
        private long GovernmentID { get; }
        public WireTransferHistoryContext(long governmentID) : base()
        {
            GovernmentID = governmentID;
        }

        internal override Icon ExplorerIcon => Properties.Resources.icn_money;

        internal override IExplorerControl<WireTransferHistory> GetControlForModel(WireTransferHistory model)
        {
            return new WireTransferHistoryControl()
            {
                Model = model
            };
        }

        internal override async Task<List<DropDownItem<WireTransferHistory>>> GetInitialListItems()
        {
            GetData getTransfers = new GetData(DataAccess.APIs.GovernmentPortal, "WireTransferHistory/GetAll");
            getTransfers.AddGovHeader(GovernmentID);
            List<WireTransferHistory> wireTransferHistories = await getTransfers.GetObject<List<WireTransferHistory>>() ?? new List<WireTransferHistory>();

            return wireTransferHistories
                    .OrderByDescending(wth => wth.TransferTime)
                    .Select(wth => 
                            new DropDownItem<WireTransferHistory>(wth,
                                                                  GetDropDownItemText(wth.TransferTime ?? new DateTime(),
                                                                                      wth.CompanyFrom?.Name ?? wth.GovernmentFrom?.Name,
                                                                                      wth.CompanyTo?.Name ?? wth.GovernmentTo?.Name)))
                    .ToList();
        }

        public static string GetDropDownItemText(DateTime transferTime, string from, string to)
        {
            return string.Format("{0}: {1} -> {2}", transferTime.ToString("MM/dd/yyyy"), from, to);
        }
    }
}
