using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscordAndDragons.Discord
{
    public class ContentController
    {
        private List<string> InitiativeContent;
        private List<string> SavingThrowContent;
        private List<string> SkillCheckContent;
        private List<string> AttackContent;
        private List<string> DamageContent;
        private List<string> DeathSaveContent;
        private Random Random;

        public ContentController()
        {
            InitiativeContent = GetContent(Properties.Resources.InitiativeContent);
            SavingThrowContent = GetContent(Properties.Resources.SavingThrowContent);
            SkillCheckContent = GetContent(Properties.Resources.SkillCheckContent);
            AttackContent = GetContent(Properties.Resources.AttackContent);
            DamageContent = GetContent(Properties.Resources.DamageContent);
            DeathSaveContent = GetContent(Properties.Resources.DeathSaveContent);
            Random = new Random();
        }

        public string GetContent(RollInformation rollInformation)
        {
            List<string> contentList = DetermineContentType(rollInformation.RollType);

            if (contentList.IsNullOrEmpty())
                return DefaultContent(rollInformation);

            var index = Random.Next(0, contentList.Count);
            return CustomiseContent(contentList[index], rollInformation);
        }

        private string CustomiseContent(string rawContent, RollInformation rollInformation)
        {
            var contentDictionary = new Dictionary<string, string>()
            {
                ["{0}"] = rollInformation.CharacterName,
                ["{1}"] = rollInformation.SkillAsReadableString(),
                ["{2}"] = rollInformation.DiceTypeAsReadableString(),
                ["{3}"] = rollInformation.DiceRoll.ToString(),
                ["{4}"] = rollInformation.Modifier.ToString(),
                ["{5}"] = rollInformation.Result.ToString(), 
                ["{6}"] = rollInformation.WeaponName, 
            };

            var cleansedContent = rawContent;

            foreach (KeyValuePair<string, string> variable in contentDictionary)
            {
                cleansedContent = cleansedContent.Replace(variable.Key, variable.Value);
            }

            return cleansedContent;
        }

        private List<string> DetermineContentType(RollType rollType)
        {
            switch (rollType)
            {
                case RollType.SavingThrow:
                    return SavingThrowContent;
                case RollType.SkillCheck:
                    return SkillCheckContent;
                case RollType.Attack:
                    return AttackContent;
                case RollType.Damage:
                    return DamageContent;
                case RollType.DeathSave:
                    return DeathSaveContent;
                case RollType.Initative:
                    return InitiativeContent;
                default:
                    return new List<string>();
            }
        }

        private List<string> GetContent(string textContent)
        {
            return textContent.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        #region Default content

        private string DefaultContent(RollInformation rollInformation)
        {
            switch (rollInformation.RollType)
            {
                case RollType.SavingThrow:
                    return $"{rollInformation.CharacterName} attempts a {rollInformation.SkillAsReadableString()} saving throw ({rollInformation.DiceTypeAsReadableString()}): Rolled a {rollInformation.DiceRoll} with a modifier of {rollInformation.Modifier} for a total of {rollInformation.Result}";
                case RollType.SkillCheck:
                    return $"{rollInformation.CharacterName} performs a {rollInformation.SkillAsReadableString()} skill check ({rollInformation.DiceTypeAsReadableString()}): Rolled a {rollInformation.DiceRoll} with a modifier of {rollInformation.Modifier} for a total of {rollInformation.Result}";
                case RollType.Attack:
                    return $"{rollInformation.CharacterName} performs an attack with their {rollInformation.WeaponName}({rollInformation.DiceTypeAsReadableString()}) : Rolled a {rollInformation.DiceRoll} with a modifier of {rollInformation.Modifier} for a total of {rollInformation.Result}";
                case RollType.Damage:
                    return $"{rollInformation.CharacterName} rolls for damage using their {rollInformation.WeaponName}({rollInformation.DiceTypeAsReadableString()}) : Rolled a {rollInformation.DiceRoll} with a modifier of {rollInformation.Modifier} for a total of {rollInformation.Result}";
                case RollType.DeathSave:
                    return $"{rollInformation.CharacterName} rolled for a death saving throw! Rolled a {rollInformation.Result}({rollInformation.DiceTypeAsReadableString()}). {DetermineDeathSaveContent(rollInformation.CurrentHealthState)}";
                case RollType.Initative:
                    return $"{rollInformation.CharacterName} rolls for initiative and rolled a {rollInformation.DiceRoll}({rollInformation.DiceTypeAsReadableString()}). With a modifier of {rollInformation.Modifier} results in {rollInformation.Result}";
                default:
                    return $"";
            }
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

        #endregion

    }
}