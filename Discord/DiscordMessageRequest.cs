using Discord.WebSocket;
using System.Net.Http;

namespace MyDick.Discord
{
    public class DiscordMessageRequest
    {
        public HttpClient HttpClient { get; set; }
        public DiscordSocketClient DiscordClient { get; set; }
        public bool IsPrivateRoll { get; set; }
        public string Content { get; set; }
        public string ServerID { get; set; }
        public string ChannelID { get; set; }
        public string DMUserID { get; set; }
    }
}
