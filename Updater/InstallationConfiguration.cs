namespace Updater
{
    public class InstallationConfiguration
    {
        public string InstallDirectory { get; set; }
        public bool MakeStartMenuIcon { get; set; }
        public bool MakeDesktopIcon { get; set; }
        public string MinecraftDirectory { get; set; }
        public bool AcceptedToS { get; set; }
    }
}
