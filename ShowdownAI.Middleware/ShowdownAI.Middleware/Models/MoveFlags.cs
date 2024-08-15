namespace ShowdownAI.Middleware.Models
{
    public class MoveFlags
    {
        public bool? Allyanim { get; set; } // The move plays its animation when used on an ally.
		public bool? Bypasssub { get; set; } // Ignores a target's substitute.
		public bool? Bite { get; set; } // Power is multiplied by 1.5 when used by a Pokemon with the Ability Strong Jaw.
		public bool? Bullet { get; set; } // Has no effect on Pokemon with the Ability Bulletproof.
		public bool? Cantusetwice { get; set; } // The user cannot select this move after a previous successful use.
		public bool? Charge { get; set; } // The user is unable to make a move between turns.
		public bool? Contact { get; set; } // Makes contact.
		public bool? Dance { get; set; } // When used by a Pokemon, other Pokemon with the Ability Dancer can attempt to execute the same move.
		public bool? Defrost { get; set; } // Thaws the user if executed successfully while the user is frozen.
		public bool? Distance { get; set; } // Can target a Pokemon positioned anywhere in a Triple Battle.
		public bool? Failcopycat { get; set; } // Cannot be selected by Copycat.
		public bool? Failencore { get; set; } // Encore fails if target used this move.
		public bool? Failinstruct { get; set; } // Cannot be repeated by Instruct.
		public bool? Failmefirst { get; set; } // Cannot be selected by Me First.
		public bool? Failmimic { get; set; } // Cannot be copied by Mimic.
		public bool? Futuremove { get; set; } // Targets a slot, and in 2 turns damages that slot.
		public bool? Gravity { get; set; } // Prevented from being executed or selected during Gravity's effect.
		public bool? Heal { get; set; } // Prevented from being executed or selected during Heal Block's effect.
		public bool? Metronome { get; set; } // Can be selected by Metronome.
		public bool? Mirror { get; set; } // Can be copied by Mirror Move.
		public bool? Mustpressure { get; set; } // Additional PP is deducted due to Pressure when it ordinarily would not.
		public bool? Noassist { get; set; } // Cannot be selected by Assist.
		public bool? Nonsky { get; set; } // Prevented from being executed or selected in a Sky Battle.
		public bool? Noparentalbond { get; set; } // Cannot be made to hit twice via Parental Bond.
		public bool? Nosketch { get; set; } // Cannot be copied by Sketch.
		public bool? Nosleeptalk { get; set; } // Cannot be selected by Sleep Talk.
		public bool? Pledgecombo { get; set; } // Gems will not activate. Cannot be redirected by Storm Drain / Lightning Rod.
		public bool? Powder { get; set; } // Has no effect on Pokemon which are Grass-type, have the Ability Overcoat, or hold Safety Goggles.
		public bool? Protect { get; set; } // Blocked by Detect, Protect, Spiky Shield, and if not a Status move, King's Shield.
		public bool? Pulse { get; set; } // Power is multiplied by 1.5 when used by a Pokemon with the Ability Mega Launcher.
		public bool? Punch { get; set; } // Power is multiplied by 1.2 when used by a Pokemon with the Ability Iron Fist.
		public bool? Recharge { get; set; } // If this move is successful, the user must recharge on the following turn and cannot make a move.
		public bool? Reflectable { get; set; } // Bounced back to the original user by Magic Coat or the Ability Magic Bounce.
		public bool? Slicing { get; set; } // Power is multiplied by 1.5 when used by a Pokemon with the Ability Sharpness.
		public bool? Snatch { get; set; } // Can be stolen from the original user and instead used by another Pokemon using Snatch.
		public bool? Sound { get; set; } // Has no effect on Pokemon with the Ability Soundproof.
		public bool? Wind { get; set; } // Activates the Wind Power and Wind Rider Abilities.
    }
}
