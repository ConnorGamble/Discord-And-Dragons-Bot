using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace MyDick.Discord
{
    public static class Helpers
    {
        public static bool IsCommand(string message)
        {
            if (message[0] == '!')
                return true;
            else
                return false;
        }

        public static bool IsEmote(string message)
        {
            string emojiList = " <:SassyChoice:614514191897722890><:WAAAHH:367060898457583616> <:Simon5Head:589928513348436121> <:Sassy_Choice:426084105457762339> <:PogChamp:367061192625094659> <:Penis:367057752259821579> <:PedoBear:595324585709142016> <:NayeonDisgust:606861141620031488> <:MingLee:367061126342508544> <:MelWot:370265770070114305> <:MelWot:492792192000327710> <:MelsyCunt:367055304719990795> <:JackSlightSmile:367059949584515082> <:DoggoScared:471347360644202516> <:Dadbury:595323587695476767> <:AlexLikey:606861141578088457> <:AlexDerp:471346689677066240> <:AlexConfused:469968458600415233> <:AlexCaveMan:486986740301692938>";

            if (emojiList.Contains(message))
                return true;
            else
                return false;
        }

        public static bool ShouldRepeatEmote()
        {
            var shouldRepeat = new Random();

            var randomNumber = shouldRepeat.Next(0, 10);

            if (randomNumber < 3)
                return true;
            else
                return false;
        }

        public static string DetermineContentToSendToDiscord(RollInformation rollInfo, RollType rollType)
        {
            // saving throw, skill check attack, damage
            // Name rolled for a {RollType} on {SkillType}. Rolled a roll with a modifier for a total
            // Name rolled an attack. Rolled a roll with a modifier for a total
            var content = $"Rolled a {rollInfo.DiceRoll} with modifier of {rollInfo.Modifier} for a total of {rollInfo.Result}";
            var skill = MapToReadableString(rollInfo.SkillType);

            switch (rollType)
            {
                case RollType.Unknown:
                    break;
                case RollType.SavingThrow:
                    content = $"Rolled for a Saving Throw ({skill}): Rolled a {rollInfo.DiceRoll} with a modifier of {rollInfo.Modifier} for a total of {rollInfo.Result}";
                    break;
                case RollType.SkillCheck:
                    content = $"Rolled for a Skill check ({skill}): Rolled a {rollInfo.DiceRoll} with a modifier of {rollInfo.Modifier} for a total of {rollInfo.Result}";
                    break;
                case RollType.Attack:
                    content = $"Attack roll: Rolled a {rollInfo.DiceRoll} with a modifier of {rollInfo.Modifier} for a total of {rollInfo.Result}";
                    break;
                case RollType.Damage:
                    content = $"Damage roll: Rolled a {rollInfo.DiceRoll} with a modifier of {rollInfo.Modifier} for a total of {rollInfo.Result}";
                    break;
                default:
                    break;
            }

            return content;
        }

        private static string MapToReadableString(SkillType skillType)
        {
            switch (skillType)
            {
                case SkillType.AnimalHandling:
                    return "Animal Handling";
                case SkillType.SleightOfHand:
                    return "Sleight of Hand";
                default:
                    return skillType.ToString();
            }
        }

        public static void SendToCorrectTextChat(DiscordMessageRequest request)
        {
            if (request.IsPrivateRoll)
                SendMessageToDM(request.DiscordClient, request.Content);
            else
                SendToDiscord(request.HttpClient, request.Content);
        }

        public async static void SendToDiscord(HttpClient client, string content)
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
                await Task.Run(async () => await client.PostAsync(webhookUrl, httpContent));
            }
            catch
            {
                // Swallow errors as you're likely offline
            }
        }

        public async static void SendMessageToDM(DiscordSocketClient _Client, string discordContent)
        {
            await Task.Run(async () =>
            {
                var user = _Client.GetUser(ulong.Parse("143372520731443200"));
                var channels = user.GetOrCreateDMChannelAsync().Result;
                channels.SendMessageAsync(discordContent);
            });
        }
    }

    public enum RollType
    {
        Unknown,
        SavingThrow,
        SkillCheck,
        Attack,
        Damage
    }

    public enum SkillType
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma,
        Acrobatics,
        AnimalHandling,
        Arcana,
        Athletics,
        Deception,
        History,
        Insight,
        Intimidation,
        Investigation,
        Medicine,
        Nature,
        Perception,
        Performance,
        Persuasion,
        Religion,
        SleightOfHand,
        Stealth,
        Survival
    }
}