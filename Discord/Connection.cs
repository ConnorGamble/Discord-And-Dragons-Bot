using System;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;

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
            await _Client.LoginAsync(TokenType.Bot, "NDEyMjEyNjAwNTUwNDU3MzU0.XV8O_A.OsNXPA-T7zJpBPALThAJMRyFOBo");

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

        public void SendToCorrectTextChat(DiscordMessageRequest request)
        {
            if (request.IsPrivateRoll)
                SendMessageToDM(request.Content);
            else
                SendToDiscord(request.Content);
        }

        public async void SendToDiscord(string content)
        {
            var payload = new DiscordMessageObject
            {
                Content = content
            };

            var webhookUrl = "https://discordapp.com/api/webhooks/614870234654048289/HUUAliWpSPnse8LU8oIpQflHhYDb9GIA1VC08z2aiXp64tjLl52J9MibwzfG71D1iiZ9";

            var stringPayload = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            try
            {
                await Task.Run(async () => await httpClient.PostAsync(webhookUrl, httpContent));
            }
            catch
            {
                // Swallow errors as you're likely offline
            }
        }

        public async void SendMessageToDM(string discordContent)
        {
            await Task.Run(() =>
            {
                var user = _Client.GetUser(ulong.Parse("143372520731443200"));
                var channels = user.GetOrCreateDMChannelAsync().Result;
                _ = channels.SendMessageAsync(discordContent);
            });
        }
    }
}
