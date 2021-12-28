using MesaSuite.Common.Data;

namespace GovernmentPortal.Extensions
{
    public static class DataAccessExtensions
    {
        public static void AddGovHeader(this DataAccess dataAccess, long governmentID)
        {
            dataAccess.Headers.Add("GovernmentID", governmentID.ToString());
        }
    }
}
