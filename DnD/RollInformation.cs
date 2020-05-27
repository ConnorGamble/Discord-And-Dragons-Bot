using DiscordAndDragons.Discord;

namespace DiscordAndDragons
{
    public class RollInformation
    {
        /// <summary>
        /// The number which was rolled on the dice
        /// </summary>
        public int DiceRoll { get; set; }
        /// <summary>
        /// The modifier to be applied to the DiceRoll
        /// </summary>
        public int Modifier { get; set; }
        /// <summary>
        /// The result of the roll +/- the dice roll
        /// </summary>
        public int Result { get; set; }
        /// <summary>
        /// The type of roll being performed
        /// </summary>
        public RollType RollType { get; set; }
        /// <summary>
        /// The type of skill being performed
        /// </summary>
        public SkillType SkillType { get; set; }
        /// <summary>
        /// The type of dice being rolled (D20, D12 etc.)
        /// </summary>
        public DiceType DiceType { get; set; }
        /// <summary>
        /// The name of the character performing the roll
        /// </summary>
        public string CharacterName { get; set; }
        /// <summary>
        /// The name of the weapon being used if there is one
        /// </summary>
        public string WeaponName { get; set; }
        /// <summary>
        /// Whether or not this roll has an error. Can only really occur when getting the modifier
        /// </summary>
        public bool HasError { get; set; } = false;

        public CurrentHealthState CurrentHealthState;

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