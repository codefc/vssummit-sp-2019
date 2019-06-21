using Newtonsoft.Json;

namespace FeatureToggle.Models
{
    public class Repository
    {
        [JsonProperty("name")]
        public string Name {get; set;}

        [JsonProperty("private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("html_url")]
        public string Url { get; set; }
    }
}