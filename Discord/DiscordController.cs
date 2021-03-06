using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Net;
using Discord.WebSocket;

namespace DiscordAndDragons.Discord
{
    public class DiscordController
    {
        public DiscordSocketClient _Client;
        public Commands Commands;
        public ContentController ContentController;

        public DiscordController()
        {
            _ = MainAsync();
            ContentController = new ContentController();
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
            await _Client.LoginAsync(TokenType.Bot, Properties.Settings.Default.BotToken);

            // Start the bot up
            await _Client.StartAsync();

            // Stop bot from closing on it's own
            await Task.Delay(-1);
        }

        public async void CreateNewClient()
        {
            await _Client.StopAsync();

            _Client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Debug,
                AlwaysDownloadUsers = true
            });

            // Attach the ready client event
            _Client.Ready += Client_Ready;

            try
            {
                await _Client.LoginAsync(TokenType.Bot, Properties.Settings.Default.BotToken);
            }
            catch(HttpException exception)
            {
                Forms.Helpers.CreateMessageBox("Unauthorised access to this bot. Be sure the bot token is correct and try again.");
                return;
            }

            // Start the bot up
            await _Client.StartAsync();

            // When connected, display a text box
            _Client.Connected += _Client_Connected;

            await Task.Delay(1000);

            // Stop bot from closing on it's own
            await Task.Delay(-1);
        }

        private async Task _Client_Connected()
        {
            Forms.Helpers.CreateMessageBox($"Connected to bot called: {_Client.CurrentUser.Username}");
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
            _Client.Dispose();
        }

        public void SendToCorrectTextChat(MessageRequest request)
        {
            if (request.IsPrivateRoll)
                SendMessageToDM(request);
            else
                SendToPublicChannel(request);
        }

        public async void SendToPublicChannel(MessageRequest request)
        {
            await Task.Run(() =>
            {
                var guild = _Client.GetGuild(ulong.Parse(request.Ids.ServerID));
                if (guild == null)
                {
                    Forms.Helpers.CreateMessageBox($"Could not find the server with the specified ID. ({request.Ids.ServerID})");
                    return;
                }

                var channel = guild.GetTextChannel(ulong.Parse(request.Ids.ChannelID));
                if (channel == null)
                {
                    Forms.Helpers.CreateMessageBox($"Could not find the channel with the specified ID. ({request.Ids.ChannelID})");
                    return;
                }

                channel.SendMessageAsync(request.Content);
            });
        }

        public async void SendMessageToDM(MessageRequest request)
        {
            await Task.Run(() =>
            {
                var user = _Client.GetUser(ulong.Parse(request.Ids.DMUserID));
                if (user == null)
                {
                    Forms.Helpers.CreateMessageBox($"Could not find the DM user with the specified ID. ({request.Ids.DMUserID}) Ensure you have also enabled the 'Server Members Intent' on your Discord bot.");
                    return;
                }
                var channels = user.GetOrCreateDMChannelAsync().Result;
                _ = channels.SendMessageAsync(request.Content);
            });
        }

        public string DetermineMultipleRollsContent(List<RollInformation> listOfRolls)
        {
            var character = listOfRolls.First().CharacterName;
            var diceType = listOfRolls.First().DiceTypeAsReadableString();
            var weaponName = listOfRolls.First().WeaponName;
            var modifier = listOfRolls.First().Modifier;

            var unmoddedRolls = "";
            var moddedRolls = "";

            for (int i = 0; i < listOfRolls.Count; i++)
            {
                RollInformation roll = listOfRolls[i];

                if(i == listOfRolls.Count -1)
                {
                    unmoddedRolls = unmoddedRolls + $"{roll.DiceRoll}.";
                    moddedRolls = moddedRolls + $"{roll.Result}.";
                    continue;
                }

                unmoddedRolls = unmoddedRolls + $"{roll.DiceRoll}, ";
                moddedRolls = moddedRolls + $"{roll.Result}, ";
            }

            var content = 
                $"{character} rolled {listOfRolls.Count} {diceType}'s when attacking with their {weaponName}" +
                $"\nThe rolls were {unmoddedRolls}" +
                $"\nAdding a modifier of {modifier}, the results are {moddedRolls}";

            return content;
        }

        public string DetermineContentToSendToDiscord(RollInformation rollInfo)
        {
            return ContentController.GetContent(rollInfo);
        }

        public bool CanLoginWithBotToken()
        {
            return !Task.Run(() => _Client.LoginAsync(TokenType.Bot, Properties.Settings.Default.BotToken)).IsFaulted;
        }


        public void CanFindTextOutput(string id, TextOutputType textOutputType)
        {
            var messageContent = $"Could not find given {textOutputType.ToString()} with id: {id}";

            if (!CanParseUlong(id))
            {
                Forms.Helpers.CreateMessageBox($"A valid ID is needed to search for a server. \n ID: {id}");
                return;
            }

            var parsedId = ulong.Parse(id);

            switch (textOutputType)
            {
                case TextOutputType.Server:
                    var foundServer = _Client.GetGuild(parsedId);

                    if(foundServer == null)
                    {
                        messageContent = "Could not find server. Please ensure you can find the correct server before searching for a channel.";
                        break;
                    }

                    messageContent = $"Found server called: {foundServer?.Name}";
                    break;
                case TextOutputType.Channel:
                    if(!CanParseUlong(Properties.Settings.Default.ServerID))
                    {
                        messageContent = "Could not find server using given ServerID. (ID in wrong format)";
                        break;
                    }

                    var server = _Client.GetGuild(ulong.Parse(Properties.Settings.Default.ServerID));
                    if (server == null)
                    {
                        messageContent = "Could not find server. Please ensure you can find the correct server before searching for a channel.";
                        break;
                    }

                    var textChannel = server.GetTextChannel(parsedId);

                    if (textChannel == null)
                    {
                        messageContent = "Could not find text channel.";
                        break;
                    }

                    messageContent = $"Found channel called: {textChannel.Name}";
                    break;
                case TextOutputType.DMUser:

                    var foundUser = _Client.GetUser(parsedId);

                    if(foundUser == null)
                    {
                        messageContent = "Could not find the specified user. Please ensure the ID is correct and you have connected to the correct server.";
                        break;
                    }

                    messageContent = $"Found user called: {foundUser.Username}";
                    break;
            }

            Forms.Helpers.CreateMessageBox(messageContent);

        }

        private bool CanParseUlong(string id)
        {
            if (ulong.TryParse(id, out _))
                return true;
            else
                return false;
        }


        // Bunch of different methods on here for "get channel, get server, get user etc and return name so that it's verifiable. Add in a message box which says found "X channel or whatever"
    }

    public enum TextOutputType
    {
        Server, 
        Channel, 
        DMUser
    }
}
