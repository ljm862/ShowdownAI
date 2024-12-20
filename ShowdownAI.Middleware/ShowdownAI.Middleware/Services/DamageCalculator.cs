﻿using ShowdownAI.Middleware.Models;
using ShowdownAI.Middleware.Services.Interfaces;

namespace ShowdownAI.Middleware.Services
{
    public class DamageCalculator
    {
        private readonly IBattleTracker _battleTracker;

        private readonly float randomRatio = 0.925f; // Mean value of the random roles

        public DamageCalculator(IBattleTracker battleTracker)
        {
            _battleTracker = battleTracker;
        }

        /// <summary>
        /// https://bulbapedia.bulbagarden.net/wiki/Damage
        /// </summary>
        /// <param name="move"></param>
        /// <param name="attacker"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public float ExpectedDamage(MoveData move, Pokemon attacker, Pokemon target)
        {
            var effectiveness = CalculateTypeEffectiveness(move.Type, target);
            Console.WriteLine($"Type Effectiveness of [{move.Name}] is {effectiveness}");
            if (effectiveness == 0f) return 0f;

            var gamma = ((2.0f / 5.0f) * (float)attacker.Level) + 2f;
            Console.WriteLine($"Gamma is [{gamma}]");
            var alpha = ((gamma * move.BasePower * (move.Method == AttackMethod.Physical ? ((float)attacker.Stats.Atk / target.Stats.Def) : ((float)attacker.Stats.Spa / attacker.Stats.Spd))) / 50.0f) + 2;
            Console.WriteLine($"Alpha is [{alpha}]");
            var damage = alpha * CalculateWeatherMultiplier(move, attacker, target) * CalculateCritical(move, attacker, target) * randomRatio * CalculateStab(move.Type, attacker) * effectiveness * BurnCheck(move, attacker) * MiscChecks();
            return Math.Max(1, damage);
        }


        private float CalculateWeatherMultiplier(MoveData move, Pokemon attacker, Pokemon target)
        {
            if (attacker.Ability == "cloudnine" || attacker.Ability == "airlock" || target.Ability == "cloudnine" || target.Ability == "airlock") return 1f;

            var weather = _battleTracker.GetCurrentWeather();
            var baseValue = 1f;
            if (weather == Weather.Rain)
            {
                if (move.Type == TypeName.Water)
                {
                    baseValue = 1.5f;
                }
                if (move.Type == TypeName.Fire)
                {
                    baseValue = 0.5f;
                }
            }
            if (weather == Weather.Sunlight)
            {
                if (move.Type == TypeName.Water)
                {
                    baseValue = 0.5f;
                }
                if (move.Type == TypeName.Fire || move.Id == "hydrostream")
                {
                    baseValue = 1.5f;
                }
            }
            Console.WriteLine($"Weather Multiplier for [{move.Name}] is {baseValue}");
            return baseValue;
        }

        // Tried to get an average value output for this. Not sure if my maths is done right
        private float CalculateCritical(MoveData move, Pokemon attacker, Pokemon target)
        {
            if (target.Ability == "battlearmor" || target.Ability == "shellarmor") return 1f;
            var stage = 0;

            // If the pokemon has maximum friendship the probability is 2x. 
            // I assume by default they all will have max friendship but the teams investigation will answer that.
            // So for now I'm not including it in the calculation.

            //Many other exceptions here too

            if (attacker.Item == "razorclaw" || attacker.Item == "scopelens") stage += 1;
            if (attacker.Ability == "superluck") stage += 1;

            var baseChance = 1 / 24f;
            if (stage == 1)
            {
                baseChance = 1 / 8f;
            }
            else if (stage == 2)
            {
                baseChance = 1 / 2f;
            }
            else if (stage > 2)
            {
                baseChance = 1f;
            }


            var baseValue = (0.5f * baseChance) + 1;
            if (attacker.Ability == "sniper") baseValue *= 1.5f;

            Console.WriteLine($"Critical Multiplier for [{move.Name}] is {baseValue}");
            return baseValue;
        }

        private float CalculateStab(TypeName moveType, Pokemon attacker)
        {
            var multiplier = attacker.Ability == "adaptability" ? 2f : 1.5f;
            // There are several exceptions to this such as weatherball and abilities that turn normal type moves into other type moves

            var baseValue = moveType == attacker.Type ? multiplier : 1f;
            if (baseValue == 1f && attacker.Type2 != TypeName.None)
            {
                baseValue = moveType == attacker.Type2 ? multiplier : 1f;
            }

            Console.WriteLine($"STAB is {baseValue}");
            return baseValue;
        }

        private float CalculateTypeEffectiveness(TypeName moveType, Pokemon target)
        {
            var baseValue = 1f;
            baseValue *= TypeEffectivenessLookup.Lookup[moveType][(int)target.Type];
            if (target.Type2 != TypeName.None)
            {
                baseValue *= TypeEffectivenessLookup.Lookup[moveType][(int)target.Type2];
            }
            return baseValue;
        }

        private float BurnCheck(MoveData move, Pokemon attacker)
        {
            if (attacker.Status == Status.brn)
            {
                if (attacker.Ability != "guts" && move.Method == AttackMethod.Physical)
                {
                    return 0.5f;
                }
            }
            return 1f;
        }

        private float MiscChecks()
        {
            return 1f;
        }
    }
}
