using System.Threading.Tasks;

namespace FleetTracking.Reports
{
    public interface INetworkPrintable
    {
        Task NetworkPrint(long? printerID, string fileName);
    }
}
