using Newtonsoft.Json;

namespace MyDick
{
    public class DiscordMessageObject
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("tts")]
        public bool TextToSpeech { get; set; }

        [JsonProperty("embed")]
        public string Embed { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description{ get; set; }
    }
}
