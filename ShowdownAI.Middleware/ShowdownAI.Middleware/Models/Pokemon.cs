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
        public List<string> Moves { get; set; }
        public string Pokeball { get; set; }
        public bool Reviving { get; set; }
        public Stats Stats { get; set; }
        public Status Status { get; set; }
        public string Terastallized { get; set; }
        public string TeraType { get; set; }

    }
}
