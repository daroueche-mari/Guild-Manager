using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GuildManager.Controls
{
    public class CharactersConfig
    {
        [JsonPropertyName("names")]
        public Dictionary<string, List<string>> Names { get; set; } = new();

        [JsonPropertyName("classes")]
        public List<string> Classes { get; set; } = new();

        [JsonPropertyName("races")]
        public List<string> Races { get; set; } = new();

        [JsonPropertyName("power_curves")]
        public Dictionary<string, List<int>> PowerCurves { get; set; } = new();

        [JsonPropertyName("paths_images")]
        public Dictionary<string, string> PathsImages { get; set; } = new();

        [JsonPropertyName("motivations")]
        public List<string> Motivations { get; set; } = new();
    }
}
