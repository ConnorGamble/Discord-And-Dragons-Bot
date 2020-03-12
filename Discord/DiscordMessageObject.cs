using Newtonsoft.Json;

namespace MyDick
{
    public class DiscordMessageObject
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
