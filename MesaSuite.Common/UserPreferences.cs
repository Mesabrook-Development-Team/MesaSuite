using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MesaSuite.Common
{
    public class UserPreferences
    {
        private static UserPreferences _instance = null;

        [JsonProperty("sections")]
        public Dictionary<string, Dictionary<string, object>> Sections { get; set; } = new Dictionary<string, Dictionary<string, object>>();

        public static UserPreferences Get(bool forceReload = false)
        {
            if (_instance == null || forceReload)
            {
                _instance = new UserPreferences();
                _instance.Load();
            }

            return _instance;
        }

        private UserPreferences() { }

        private void Load()
        {
            if (!File.Exists("userpreferences.json"))
            {
                Save();

                return;
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader reader = new StreamReader("userpreferences.json"))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                serializer.Populate(jsonReader, this);
                jsonReader.Close();
            }
        }

        public void Save()
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter writer = new StreamWriter("userpreferences.json"))
            using (JsonTextWriter jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, this);
                jsonWriter.Flush();
                jsonWriter.Close();
            }
        }
    }
}
