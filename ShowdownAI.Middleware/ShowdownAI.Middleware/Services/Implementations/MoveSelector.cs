using ShowdownAI.Middleware.Models;
using ShowdownAI.Middleware.Services.Interfaces;

namespace ShowdownAI.Middleware.Services.Implementations
{
    public class MoveSelector : IMoveSelector
    {
        private readonly BattleTracker battleTracker;

        public MoveSelector()
        {
            battleTracker = new();
        }
        public void BuildPrediction(SideStatusRequest sideStatusRequest)
        {
            // Stores/updates the db with the latest request
            // Creates a prediction unit
            battleTracker.OurActivePokemon = sideStatusRequest.Active[0];
            Console.WriteLine("Building Prediction");
        }

        public async Task<ShowdownAction> RunPrediction()
        {
            return await Task.Run(() =>
            {
                var bestMove = 0;
                var topDmg = 0f;
                for (int i = 0; i < battleTracker.OurActivePokemon.Moves.Count; i++)
                {
                    var damageCalculator = new DamageCalculator();
                    var dmg = damageCalculator.ExpectedDamage(battleTracker.OurActivePokemon.Moves[i], battleTracker.OurCurrentPokemon, battleTracker.TheirCurrentPokemon);
                    if (topDmg <= dmg)
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
