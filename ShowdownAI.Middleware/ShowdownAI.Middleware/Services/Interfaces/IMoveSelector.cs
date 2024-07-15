using ShowdownAI.Middleware.Models;

namespace ShowdownAI.Middleware.Services.Interfaces
{
    public interface IMoveSelector
    {

        public void BuildPrediction(SideStatusRequest sideStatusRequest);

        public Task<ShowdownAction> RunPrediction();
    }
}
