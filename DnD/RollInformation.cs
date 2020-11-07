using System.Collections.Generic;
using System.Windows.Forms;

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
        /// The amount of dice which are to be rolled
        /// </summary>
        public int NumberOfDiceToRoll { get; set; }
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
        /// The tag of the weapon being used
        /// </summary>
        public string WeaponTag { get; set; }
        /// <summary>
        /// Whether or not this roll has an error. Can only really occur when getting the modifier
        /// </summary>
        public bool HasError { get; set; } = false;

        public CurrentHealthState CurrentHealthState;

        private static Dictionary<string, SkillType> SkillTypeDictionary = new Dictionary<string, SkillType>
        {
            { SkillTypeStrings.Strength, SkillType.Strength },
            { SkillTypeStrings.Dexterity, SkillType.Dexterity },
            { SkillTypeStrings.Constitution, SkillType.Constitution },
            { SkillTypeStrings.Intelligence, SkillType.Intelligence },
            { SkillTypeStrings.Wisdom, SkillType.Wisdom },
            { SkillTypeStrings.Charisma, SkillType.Charisma},
            { SkillTypeStrings.Acrobatics, SkillType.Acrobatics},
            { SkillTypeStrings.AnimalHandling, SkillType.AnimalHandling},
            { SkillTypeStrings.Arcana, SkillType.Arcana},
            { SkillTypeStrings.Athletics, SkillType.Athletics},
            { SkillTypeStrings.Deception, SkillType.Deception},
            { SkillTypeStrings.History, SkillType.History},
            { SkillTypeStrings.Insight, SkillType.Insight},
            { SkillTypeStrings.Intimidation, SkillType.Intimidation},
            { SkillTypeStrings.Investigation, SkillType.Investigation},
            { SkillTypeStrings.Medicine, SkillType.Medicine},
            { SkillTypeStrings.Nature, SkillType.Nature},
            { SkillTypeStrings.Perception, SkillType.Perception},
            { SkillTypeStrings.Performance, SkillType.Performance},
            { SkillTypeStrings.Persuasion, SkillType.Persuasion},
            { SkillTypeStrings.Religion, SkillType.Religion},
            { SkillTypeStrings.SleightOfHand, SkillType.SleightOfHand},
            { SkillTypeStrings.Stealth, SkillType.Stealth},
            { SkillTypeStrings.Survival, SkillType.Survival}
        };

        private static Dictionary<string, RollType> RollTypeDictionary = new Dictionary<string, RollType>
        {
            { RollTypeStrings.SavingThrow, RollType.SavingThrow },
            { RollTypeStrings.SkillCheck, RollType.SkillCheck },
            { RollTypeStrings.Attack, RollType.Attack },
            { RollTypeStrings.Damage, RollType.Damage },
            { RollTypeStrings.DeathSave, RollType.DeathSave },
            { RollTypeStrings.Initiative, RollType.Initative }
        };

        public RollInformation(object sender, DiceType diceType, bool isSkill, int numberOfRolls = 1)
        {
            var button = sender as Button;
            var tags = button.Tag?.ToString().Split(',');

            WeaponTag = tags[0];

            if (isSkill)
                SkillType = SkillTypeDictionary[tags[0].Trim()];

            RollType = RollTypeDictionary[tags[1].Trim()];

            DiceType = diceType;

            NumberOfDiceToRoll = numberOfRolls;
        }

        public RollInformation()
        {
            CharacterName = Properties.Settings.Default.CharacterName;
        }

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