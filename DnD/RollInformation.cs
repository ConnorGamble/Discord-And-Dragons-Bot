using MyDick.Discord;

namespace MyDick
{
    public class RollInformation
    {
        public int DiceRoll { get; set; }
        public int Modifier { get; set; }
        public int Result { get; set; }
        public RollType RollType { get; set; }
        public SkillType SkillType { get; set; }
        public DiceType DiceType { get; set; }
        public string CharacterName { get; set; }
        public string WeaponName { get; set; }
        public bool HasError { get; set; } = false;

        public string SkillAsReadableString()
        {
            switch (SkillType)
            {
                case SkillType.AnimalHandling:
                    return "Animal Handling";
                case SkillType.SleightOfHand:
                    return "Sleight of Hand";
                default:
                    return SkillType.ToString();
            }
        }

        public string DiceTypeAsReadableString()
        {
            return DiceType.ToString();
        }
    }
}