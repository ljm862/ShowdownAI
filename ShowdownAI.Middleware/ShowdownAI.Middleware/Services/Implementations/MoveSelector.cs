using ShowdownAI.Middleware.Models;
using ShowdownAI.Middleware.Services.Interfaces;

namespace ShowdownAI.Middleware.Services.Implementations
{
    public class MoveSelector : IMoveSelector
    {
        private readonly IBattleTracker _battleTracker;
        private readonly IMoveDataLookup _moveDataLookup;
        private readonly ITypeLookup _typeLookup;

        public MoveSelector(IMoveDataLookup moveDataLookup, IBattleTracker battleTraker, ITypeLookup typeLookup)
        {
            _moveDataLookup = moveDataLookup;
            _battleTracker = battleTraker;
            _typeLookup = typeLookup;
        }

        public void BuildPrediction(SideStatusRequest sideStatusRequest)
        {
            Console.WriteLine("Building Prediction");
            // Stores/updates the db with the latest request
            // Creates a prediction unit

            var curPokemon = sideStatusRequest.Side.Pokemon[0];
            if (curPokemon.Type.Equals(TypeName.None))
            {
                var types = _typeLookup.GetTypeData(curPokemon.Name);
                curPokemon.Type = types.Item1;
                curPokemon.Type2 = types.Item2;
            }

            var theirPokemon = Pokemon.DefaultPokemon();

            _battleTracker.UpdateTurnStart(sideStatusRequest.Active[0], curPokemon, theirPokemon);
        }

        public async Task<ShowdownAction> RunPrediction()
        {
            return await Task.Run(() =>
            {
                return GetBestMove();
            });

        }

        private ShowdownAction GetBestMove()
        {
            var bestMove = 0;
            var topDmg = 0f;
            var damageCalculator = new DamageCalculator(_battleTracker);

            var moveData = ConvertMoveInfoToMoveData(_battleTracker.GetActivePokemon().Moves); // TODO: Cache this in BattleTracker
            Console.WriteLine("=====Begin Move Calculation=====");
            for (int i = 0; i < _battleTracker.GetActivePokemon().Moves.Count; i++)
            {
                var dmg = damageCalculator.ExpectedDamage(moveData[i], _battleTracker.GetOurCurrentPokemon(), _battleTracker.GetTheirCurrentPokemon());
                Console.WriteLine($"Move [{moveData[i].Name}] expected damage of {dmg}");
                if (topDmg < dmg)
                {
                    topDmg = dmg;
                    bestMove = i + 1;
                }
                Console.WriteLine("==========");
            }
            Console.WriteLine("=====End Move Calculation=====");
            Console.WriteLine($"Best Move is: {bestMove.ToString()}");
            return (ShowdownAction)bestMove;
        }

        // Could probably extract this into its own helper class or something
        private List<MoveData> ConvertMoveInfoToMoveData(List<MoveInfo> moves)
        {
            var moveDataList = new List<MoveData>();
            for (int i = 0; i < moves.Count; i++)
            {
                var moveDataObj = _moveDataLookup.GetMoveData(moves[i].Id);
                moveDataList.Add(moveDataObj);
            }
            return moveDataList;
        }
    }
}
