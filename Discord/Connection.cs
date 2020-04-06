using System;
using System.Net.Http;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace MyDick.Discord
{
    public class Connection
    {
        public DiscordSocketClient _Client;
        public Commands Commands;
        public HttpClient httpClient;

        public Connection()
        {
            httpClient = new HttpClient();
            MainAsync();
        }

        private async Task MainAsync()
        {
            // Creates a new client where you can specify information about the backend
            _Client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Debug,
                AlwaysDownloadUsers = true
            });

            // Declare a new instance of the command handler
            Commands = new Commands(_Client);

            // This method is hit whenever a message has been recieved
            _Client.MessageReceived += Client_MessageReceived;

            // Add all of the commands from inside of this project
            //await Commands.AddModulesAsync(Assembly.GetEntryAssembly());

            // Attach the ready client event
            _Client.Ready += Client_Ready;

            // Attach the client log event
            _Client.Log += Client_Log;

            // Tell the bot to login to Discord
            /// ########################## SHOULD NOT BE COMMITTING ME, THIS IS PERSONAL INFORMATION
            await _Client.LoginAsync(TokenType.Bot, "ABOTTOKEN");
            /// ########################## SHOULD NOT BE COMMITTING ME, THIS IS PERSONAL INFORMATION

            // Start the bot up
            await _Client.StartAsync();

            // Stop bot from closing on it's own
            await Task.Delay(-1);
        }

        private async Task Client_Log(LogMessage arg)
        {
            // Logs
            Console.WriteLine($"Time: {DateTime.Now} Log: {arg.Message} : Level: {arg.Severity}");
        }

        private async Task Client_Ready()
        {
            await _Client.SetGameAsync("with dragons");
        }

        private async Task Client_MessageReceived(SocketMessage arg)
        {
            Console.WriteLine(arg);
            var message = arg as SocketUserMessage;

            if (message.Author.IsBot)
                return;

            var isEmote = Helpers.IsEmote(message.Content);

            if (Helpers.IsCommand(message.Content) || isEmote)
            {
                var Context = new SocketCommandContext(_Client, message);
                Commands.HandleCommand(Context, message, isEmote);
            }
        }

        public async void LogoutBot()
        {
            await _Client.LogoutAsync();
            await _Client.StopAsync();
        }

        public void SendToCorrectTextChat(DiscordMessageRequest request)
        {
            if (request.IsPrivateRoll)
                SendMessageToDM(request);
            else
                SendToPublicChannel(request);
        }

        public async void SendToPublicChannel(DiscordMessageRequest request)
        {
            await Task.Run(() =>
            {
                var guild = _Client.GetGuild(ulong.Parse(request.ServerID));
                var channel = guild.GetTextChannel(ulong.Parse(request.ChannelID));
                channel.SendMessageAsync(request.Content);
            });
        }

        public async void SendMessageToDM(DiscordMessageRequest request)
        {
            await Task.Run(() =>
            {
                var user = _Client.GetUser(ulong.Parse(request.DMUserID));
                var channels = user.GetOrCreateDMChannelAsync().Result;
                _ = channels.SendMessageAsync(request.Content);
            });
        }
    }
}
