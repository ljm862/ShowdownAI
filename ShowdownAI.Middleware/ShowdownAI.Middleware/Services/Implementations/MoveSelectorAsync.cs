using ShowdownAI.Middleware.Models;
using ShowdownAI.Middleware.Services.Interfaces;

namespace ShowdownAI.Middleware.Services.Implementations
{
    /// <summary>
    /// Requires a message queue that will have messages stored in that the actor will read from
    /// </summary>
    public class MoveSelectorAsync : IMoveSelector
    {
        private readonly Random rnd;
        public MoveSelectorAsync()
        {
            rnd = new Random();
        }

        public void BuildPrediction(SideStatusRequest sideStatusRequest)
        {
            // Stores/updates the db with the latest request
            // Creates a prediction unit
            Console.WriteLine("Building Prediction");
        }

        public async Task<ShowdownAction> RunPrediction()
        {
            _ = Task.Run(() =>
            {
                for (int i = 1; i < 1000000000; i++)
                {
                    var j = i;
                }
                Console.WriteLine("And fin");
                return (ShowdownAction)rnd.Next(1, 10);
            });
            Console.WriteLine("Finished");
            return ShowdownAction.Error;
        }
    }
}
