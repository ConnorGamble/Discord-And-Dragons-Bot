using System;

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

        public static string DetermineContentToSendToDiscord(RollInformation rollInfo)
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

        private static string DetermineDeathSaveContent(CurrentHealthState currentHealthState)
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
    }

    public enum RollType
    {
        Unknown,
        SavingThrow,
        SkillCheck,
        Attack,
        Damage,
        DeathSave
    }

    public enum SkillType
    {
        Unknown,
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

    public enum DiceType
    {
        Unknown, 
        D4, 
        D6, 
        D8, 
        D10,
        D12,
        D20, 
        D100
    }
}