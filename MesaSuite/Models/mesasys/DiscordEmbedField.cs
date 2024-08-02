namespace MesaSuite.Models.mesasys
{
    public class DiscordEmbedField
    {
        public long? DiscordEmbedFieldID { get; set; }
        public long? DiscordEmbedID { get; set; }
        public DiscordEmbed DiscordEmbed { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsInline { get; set; }
    }
}
