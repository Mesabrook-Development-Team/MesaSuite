using MesaSuite.Common.Data;

namespace CompanyStudio.Extensions
{
    public static class DataAccessExt
    {
        public static void AddCompanyHeader(this DataAccess dataAccess, long? companyID)
        {
            dataAccess.Headers.Add("CompanyID", companyID?.ToString());
        }

        public static void AddLocationHeader(this DataAccess dataAccess, long? companyID, long? locationID)
        {
            dataAccess.AddCompanyHeader(companyID);
            dataAccess.Headers.Add("LocationID", locationID?.ToString());
        }
    }
}
