using ClussPro.ObjectBasedFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels.security;

namespace API_System.Cache
{
    public static class ProgramCache
    {
        public static Dictionary<long, Tuple<DateTime, List<string>>> ProgramsByUser = new Dictionary<long, Tuple<DateTime, List<string>>>();

        public async static Task<bool> UserHasProgram(long userID, string key)
        {
            if (!ProgramsByUser.ContainsKey(userID) || ProgramsByUser[userID].Item1 < DateTime.Now)
            {
                List<string> programKeys = await Task.Run(() =>
                {
                    User user = DataObject.GetReadOnlyByPrimaryKey<User>(userID, null, new string[] { "UserPrograms.Program.Key" });
                    return user?.UserPrograms.Select(up => up.Program.Key).ToList();
                });

                ProgramsByUser[userID] = new Tuple<DateTime, List<string>>(DateTime.Now.AddSeconds(30), programKeys ?? new List<string>());
            }

            return ProgramsByUser[userID].Item2.Contains(key);
        }
    }
}