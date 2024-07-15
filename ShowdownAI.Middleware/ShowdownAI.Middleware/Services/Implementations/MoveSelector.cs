using ShowdownAI.Middleware.Models;
using ShowdownAI.Middleware.Services.Interfaces;

namespace ShowdownAI.Middleware.Services.Implementations
{
    public class MoveSelector : IMoveSelector
    {
        public void BuildPrediction(SideStatusRequest sideStatusRequest)
        {
            // Stores/updates the db with the latest request
            // Creates a prediction unit
            Console.WriteLine("Building Prediction");
        }

        public async Task<ShowdownAction> RunPrediction()
        {

            await Task.Run(() =>
            {
                for (int i = 1; i < 1000000000; i++)
                {
                    var j = i;
                }
            });
            Console.WriteLine("Finished");
            return ShowdownAction.Move1;
        }
    }
}
