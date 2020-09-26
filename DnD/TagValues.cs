namespace DiscordAndDragons.DnD.TagValues
{
    public struct RollType
    {
        public const string SavingThrow = "SavingThrow";
        public const string SkillCheck = "SkillCheck";
        public const string Attack = "Attack";
        public const string Damage = "Damage";
        public const string DeathSave = "DeathSave";

        private Dictionary<string, RollType> RollTypeDictionary = new Dictionary<string, RollType>
        { 
            { SavingThrow, RollType.SavingThrow },
            { SkillCheck, RollType.SkillCheck },
            { Attack, RollType.Attack },
            { Damage, RollType.Damage },
            { DeathSave, RollType.DeathSave }
        };
    }

    public struct SkillType
    {
        public const string Strength = "Strength";
        public const string Dexterity = "Dexterity";
        public const string Constitution = "Constitution";
        public const string Intelligence = "Intelligence";
        public const string Wisdom = "Wisdom";
        public const string Charisma = "Charisma";
        public const string Acrobatics = "Acrobatics";
        public const string AnimalHandling = "AnimalHandling";
        public const string Arcana = "Arcana";
        public const string Athletics = "Athletics";
        public const string Deception = "Deception";
        public const string History = "History";
        public const string Insight = "Insight";
        public const string Intimidation = "Intimidation";
        public const string Investigation = "Investigation";
        public const string Medicine = "Medicine";
        public const string Nature = "Nature";
        public const string Perception = "Perception";
        public const string Performance = "Performance";
        public const string Persuasion = "Persuasion";
        public const string Religion = "Religion";
        public const string SleightOfHand = "SleightOfHand";
        public const string Stealth = "Stealth";
        public const string Survival = "Survival";
    }
}
