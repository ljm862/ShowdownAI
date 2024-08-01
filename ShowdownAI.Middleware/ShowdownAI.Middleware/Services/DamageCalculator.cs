using ShowdownAI.Middleware.Models;

namespace ShowdownAI.Middleware.Services
{
    public class DamageCalculator
    {
        private readonly float randomRatio = 0.925f; // Mean value of the random roles
        private readonly BattleTracker _battleTracker;

        public float WeatherMultiplier
        {
            get => _weatherMultiplier ??= CalculateWeatherMultiplier();
        }
        private float? _weatherMultiplier;

        public float Critical
        {
            get => _critical ??= CalculateCritical();
        }
        private float? _critical;

        public float Stab
        {
            get => _stab ??= CalculateStab();
        }
        private float? _stab;

        public float TypeEffectiveness
        {
            get => _typeEffectiveness ??= CalculateTypeEffectiveness();
        }
        private float? _typeEffectiveness;

        public DamageCalculator(BattleTracker battleTracker)
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
        public float ExpectedDamage(MoveInfo move, Pokemon attacker, Pokemon target)
        {
            var gamma = ((2.0f / 5) * attacker.Level) + 2;
            var alpha = ((gamma * move.Power * (move.Method == AttackMethod.Physical ? ((float)attacker.Stats.Atk / target.Stats.Def) : ((float)attacker.Stats.Spa / attacker.Stats.Spd))) / 50.0f) + 2;
            var damage = alpha * WeatherMultiplier * Critical * randomRatio * Stab * TypeEffectiveness * BurnCheck() * MiscChecks();
            return Math.Max(1, damage);
        }


        private float CalculateWeatherMultiplier()
        {
            return 1f;
        }

        private float CalculateCritical()
        {
            return 1f;
        }

        private float CalculateStab()
        {
            return 1f;
        }

        private float CalculateTypeEffectiveness()
        {
            return 1f;
        }

        private float BurnCheck()
        {
            return 1f;
        }

        private float MiscChecks()
        {
            return 1f;
        }
    }
}
