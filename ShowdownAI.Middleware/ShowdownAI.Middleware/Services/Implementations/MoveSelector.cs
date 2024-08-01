using ShowdownAI.Middleware.Models;
using ShowdownAI.Middleware.Services.Interfaces;

namespace ShowdownAI.Middleware.Services.Implementations
{
    public class MoveSelector : IMoveSelector
    {
        private readonly BattleTracker _battleTracker;

        public MoveSelector()
        {
            _battleTracker = new();
        }

        public void BuildPrediction(SideStatusRequest sideStatusRequest)
        {
            // Stores/updates the db with the latest request
            // Creates a prediction unit
            _battleTracker.UpdateTurnStart(ActivePokemon.DefaultActivePokemon(), Pokemon.DefaultPokemon(), Pokemon.DefaultPokemon());
            Console.WriteLine("Building Prediction");
        }

        public async Task<ShowdownAction> RunPrediction()
        {
            return await Task.Run(() =>
            {
                var bestMove = 0;
                var topDmg = 0f;
                for (int i = 0; i < _battleTracker.OurActivePokemon.Moves.Count; i++)
                {
                    var damageCalculator = new DamageCalculator(_battleTracker);
                    var dmg = damageCalculator.ExpectedDamage(_battleTracker.OurActivePokemon.Moves[i], _battleTracker.OurCurrentPokemon, _battleTracker.TheirCurrentPokemon);
                    if (topDmg < dmg)
                    {
                        topDmg = dmg;
                        bestMove = i + 1;
                    }
                }
                return (ShowdownAction)bestMove;

            });

        }


    }
}
