using System;
using System.Collections.Generic;
using System.IO;
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

        public string GetContent(RollType rollType)
        {
            List<string> contentList = DetermineContentType(rollType);
            var index = Random.Next(0, contentList.Count);
            // need handling for an empty list (aka something going wrong
            return contentList[index];
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

    }
}