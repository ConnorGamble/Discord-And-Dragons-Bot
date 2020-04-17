using System;
using System.Net.Http;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace MyDick.Discord
{
    public class DiscordController
    {
        public DiscordSocketClient _Client;
        public Commands Commands;
        public HttpClient httpClient;

        public DiscordController()
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
            await _Client.LoginAsync(TokenType.Bot, Properties.Settings.Default.BotToken);

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
                    DnD.Helpers.CreateMessageBox($"Could not find the server with the specified ID. ({request.Ids.ServerID})");
                    return;
                }

                var channel = guild.GetTextChannel(ulong.Parse(request.Ids.ChannelID));
                if (channel == null)
                {
                    DnD.Helpers.CreateMessageBox($"Could not find the channel with the specified ID. ({request.Ids.ChannelID})");
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
                    DnD.Helpers.CreateMessageBox($"Could not find the channel with the specified ID. ({request.Ids.DMUserID})");
                    return;
                }
                var channels = user.GetOrCreateDMChannelAsync().Result;
                _ = channels.SendMessageAsync(request.Content);
            });
        }

        public string DetermineContentToSendToDiscord(RollInformation rollInfo)
        {
            // saving throw, skill check attack, damage
            // Name rolled for a {RollType} on {SkillType}. Rolled a roll with a modifier for a total
            // Name rolled an attack. Rolled a roll with a modifier for a total
            var content = $"Rolled a {rollInfo.DiceRoll} with modifier of {rollInfo.Modifier} for a total of {rollInfo.Result}";
            var skill = rollInfo.SkillAsReadableString();
            var diceType = rollInfo.DiceTypeAsReadableString();
            var characterName = rollInfo.CharacterName;
            var weaponName = rollInfo.WeaponName;

            switch (rollInfo.RollType)
            {
                case RollType.Unknown:
                    break;
                case RollType.SavingThrow:
                    // name attempts a strength saving throw (D20) 
                    content = $"{characterName} attempts a {skill} saving throw ({diceType}): Rolled a {rollInfo.DiceRoll} with a modifier of {rollInfo.Modifier} for a total of {rollInfo.Result}";
                    break;
                case RollType.SkillCheck:
                    content = $"{characterName} performs a {skill} skill check ({diceType}): Rolled a {rollInfo.DiceRoll} with a modifier of {rollInfo.Modifier} for a total of {rollInfo.Result}";
                    break;
                case RollType.Attack:
                    content = $"{characterName} performs an attack with their {weaponName}({diceType}) : Rolled a {rollInfo.DiceRoll} with a modifier of {rollInfo.Modifier} for a total of {rollInfo.Result}";
                    break;
                case RollType.Damage:
                    content = $"{characterName} rolls for damage using their {weaponName}({diceType}) : Rolled a {rollInfo.DiceRoll} with a modifier of {rollInfo.Modifier} for a total of {rollInfo.Result}";
                    break;
                case RollType.DeathSave:
                    content = $"{characterName} rolled for a death saving throw! Rolled a {rollInfo.DiceRoll}({diceType}). {DetermineDeathSaveContent(rollInfo.CurrentHealthState)}";
                    break;
                default:
                    break;
            }

            return content;
        }

        private string DetermineDeathSaveContent(CurrentHealthState currentHealthState)
        {
            var content = string.Empty;
            var successStats = $"Successes: {currentHealthState.CurrentSuccesses}/3";
            var failureStats = $"Failures: {currentHealthState.CurrentFailures}/3";

            switch (currentHealthState.TransitionState)
            {
                case TransitionState.BecomingStable:
                    content += $"Many fall in the face of chaos... But not this one. Not today. They have become stable.";
                    break;
                case TransitionState.FallingUnconscious:
                    content += $"They are falling unconscious! Now the true test; hold fast... Or expire.";
                    break;
                case TransitionState.RemainsUnconscious:
                    content += $"They are still unconscious! As life ebbs... Terrible vistas of emptiness reveal themselves...";
                    break;
                case TransitionState.Dying:
                    content += $"They have perished. More dust. More ashes. More disappointment.";
                    break;
                case TransitionState.RevivedButUnconscious:
                    content += $"They have been revived! However they are still unconscious...";
                    break;
                default:
                    content = $"Something went wrong when determining the current health state: {currentHealthState.TransitionState}";
                    break;
            }

            return content += $" {successStats} {failureStats}";
        }

        public bool CanLoginWithBotToken()
        {
            return !Task.Run(() => _Client.LoginAsync(TokenType.Bot, Properties.Settings.Default.BotToken)).IsFaulted;
        }


        // Bunch of different methods on here for "get channel, get server, get user etc and return name so that it's verifiable. Add in a message box which says found "X channel or whatever"
    }
}
