namespace ShowdownAI.Middleware.Models
{
    public class SecondaryEffect : HitEffect
    {
        public Boosts? Boosts { get; set; }
        public int? Chance { get; set; }
        //public Ability Ability { get; set; }   // Used to flag a secondary effect as added by Poison Touch
        public bool? DustProof { get; set; }    // Applies to Sparkling Aria's secondary effect: Affected by Sheer Force but not Shield Dust.
        public bool? Kingsrock { get; set; }    // Gen 2 specific mechanics: Bypasses Substitute only on Twineedle, and allows it to flinch sleeping/frozen targets
        public HitEffect? Self { get; set; }
    }
}
