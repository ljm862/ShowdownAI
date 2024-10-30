namespace ShowdownAI.Middleware.Models
{
    public class Pokemon
    {
        public string Ability { get; set; }
        public bool Active { get; set; }
        public string BaseAbility { get; set; }
        public bool Commanding { get; set; }
        public string Condition { get; set; }
        public string Details { get; set; }
        public string Ident { get; set; }
        public string Item { get; set; }
        public int Level
        {
            get
            {
                if (level == 0)
                {
                    ParseDetails();
                }
                return level;
            }
            set { }
        }
        private int level { get; set; }
        public Dictionary<string, MoveData>? MoveDataDict { get; set; }
        public List<string> Moves { get; set; }
        public string Name
        {
            get
            {
                if (name == "")
                {
                    ParseDetails();
                }
                return name;
            }
            set { }
        }
        private string name { get; set; }
        public string Pokeball { get; set; }
        public bool Reviving { get; set; }
        public Stats Stats { get; set; }
        public Status Status { get; set; }
        public string Terastallized { get; set; }
        public TypeName TeraType { get; set; }
        public TypeName Type { get; set; }
        public TypeName? Type2 { get; set; }

        private void ParseDetails()
        {
            var splits = Details.Split(',', StringSplitOptions.TrimEntries);
            var nameStr = splits[0];
            name = nameStr;

            var levelStr = splits[1].Substring(1);
            var levelVal = int.Parse(levelStr);
            level = levelVal;
        }

        public static Pokemon DefaultPokemon()
        {
            return new Pokemon()
            {
                Ability = "beadsofruin",
                Active = true,
                BaseAbility = "beadsofruin",
                Commanding = false,
                Condition = "211/211",
                Details = "Chi-Yu, L77",
                Ident = "p2: Chi-Yu",
                Item = "choicescarf",
                Level = 77,
                MoveDataDict = new Dictionary<string, MoveData> { { "psychic", new MoveData() }, { "flamethrower", new MoveData() }, { "overheat", new MoveData() }, { "darkpulse", new MoveData() } },
                Moves = new List<string>() { "psychic", "flamethrower", "overheat", "darkpulse" },
                Pokeball = "pokeball",
                Reviving = false,
                Terastallized = "",
                TeraType = TypeName.Fire,
                Type = TypeName.Dark,
                Type2 = TypeName.Fire,
                Stats = new Stats() { Atk = 128, Def = 168, Spa = 252, Spd = 229, Spe = 199 },
                Status = Status.None
            };
        }
    }
}
