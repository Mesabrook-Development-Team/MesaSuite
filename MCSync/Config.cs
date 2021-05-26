using System;
using System.IO;
using System.Xml.Serialization;

namespace MCSync
{
    public class Config
    {
        public string ModsDirectory { get; set; }
        public string ResourcePackDirectory { get; set; }
        public string ConfigFilesDirectory { get; set; }

        public enum Modes { Client, Server }
        public Modes Mode { get; set; }

        public static Config LoadConfiguration()
        {
            if (File.Exists("config.xml"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));
                Config config = null;
                using (Stream stream = File.OpenRead("config.xml"))
                {
                    config = (Config)xmlSerializer.Deserialize(stream);
                }

                return config;
            }
            else
            {
                return new Config();
            }
        }

        public static void SaveConfiguration(Config config)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));
            File.Delete("config.xml");
            using (Stream stream = File.OpenWrite("config.xml"))
            {
                xmlSerializer.Serialize(stream, config);
            }
        }
    }
}