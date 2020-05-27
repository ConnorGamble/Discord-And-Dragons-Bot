using Discord.Commands;
using Discord.WebSocket;

namespace DiscordAndDragons.Discord
{
    public class Commands
    {
        public DiscordSocketClient _client;
        public SocketCommandContext _clientChannel;
        public Commands(DiscordSocketClient client)
        {
            _client = client;
        }

        public void HandleCommand(SocketCommandContext socketContext, SocketUserMessage userMessage, bool isEmote)
        {
            if (isEmote && Helpers.ShouldRepeatEmote())
                PrintMessage(socketContext, userMessage.Content);

            if (userMessage.Content.Contains("roll"))
                HandleRollingCommand(socketContext, userMessage);

            // Do some kind of bestiary? 

            if (userMessage.Content.Contains("keres"))
                PrintMessage(socketContext, "Keres? Oh Tickles favourite German!");

        }

        public void HandleRollingCommand(SocketCommandContext socketContext, SocketUserMessage userMessage)
        {
            // Unsure if to get rid of this at the momenet, might want to support it
            //PrintMessage(socketContext, userMessage.Content);
            // Call off to the rolling 
        }

        public void PrintMessage(SocketCommandContext socketContext, string messageToSend)
        {
            socketContext.Channel.SendMessageAsync(messageToSend);
        }
    }
}
