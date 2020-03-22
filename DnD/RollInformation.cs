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
        public string CharacterName { get; set; }
        public bool HasError { get; set; } = false;
    }
}