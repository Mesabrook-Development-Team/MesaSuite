using MesaSuite.Common.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCSync
{
    public class MCSyncFile
    {
        public static async Task<List<MCSyncFile>> GetMCSyncFiles()
        {
            GetData get = new GetData(DataAccess.APIs.MCSync, "file/getall");
            get.RequireAuthentication = false;
            get.UseHTTPS = false;
            return await get.GetObject<List<MCSyncFile>>();
        }

        public enum FileTypes
        {
            mods,
            resourcepacks,
            config,
            oresources,
            animation,
            tc_signpacks
        }

        public enum DownloadTypes
        {
            Client,
            Server,
            Common
        }

        public long? MCSyncID { get; set; }
        public FileTypes FileType { get; set; }
        public DownloadTypes DownloadType { get; set; }
        public string Path { get; set; }
        public string Filename { get; set; }
        public byte[] Checksum { get; set; }
    }
}
