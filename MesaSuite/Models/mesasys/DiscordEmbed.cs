using System.Collections.Generic;
using Towing.History;

namespace MesaSuite.Models.mesasys
{
    public class DiscordEmbed
    {
        public long? DiscordEmbedID { get; set; }
        public string Description { get; set; }
        public long Color { get; set; }
        public string URL { get; set; }
        public string AuthorName { get; set; }
        public string AuthorURL { get; set; }
        public string AuthorIconURL { get; set; }
        public string ThumbnailURL { get; set; }
        public string ImageURL { get; set; }
        public string FooterText { get; set; }
        public string FooterIconURL { get; set; }
        public string Title { get; set; }

        public List<DiscordEmbedField> DiscordEmbedFields { get; set; }
    }
}
