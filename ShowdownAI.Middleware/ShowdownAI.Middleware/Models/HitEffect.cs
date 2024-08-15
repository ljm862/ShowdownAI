namespace ShowdownAI.Middleware.Models
{
    public class HitEffect
    {
        // set pokemon conditions
        //public ??? Boosts? { get; set; }
        public string? Status { get; set; }
        public string? VolatileStatus { get; set; }

        // set side/slot conditions
        public string? SideCondition { get; set; }
        public string? SlotCondition { get; set; }

        // set field condition
        public string? PseudoWeather { get; set; }
        public string? Terrain { get; set; }
        public string? Weather { get; set; }
    }
}
