using Discord.WebSocket;
using System;
using System.Net.Http;

namespace DiscordAndDragons.Discord
{
    public class MessageRequest
    {
        public bool IsPrivateRoll { get; set; }
        public string Content { get; set; }
        public ChannelIds Ids {get;set;}
    }

    public class ChannelIds
    {
        public string ServerID { get; set; }
        public string ChannelID { get; set; }
        public string DMUserID { get; set; }

        public Tuple<bool, string> VerifyIds()
        {
            if(!ulong.TryParse(ServerID, out _))
                return Tuple.Create(false, "Server ID");

            if (!ulong.TryParse(ChannelID, out _))
                return Tuple.Create(false, "Channel ID");

            if (!ulong.TryParse(DMUserID, out _))
                return Tuple.Create(false, "DM User ID");

            return Tuple.Create(true, string.Empty);
        }
    }
}
