using ShowdownAI.Middleware.Models;

namespace ShowdownAI.Middleware.Services.Interfaces
{
    public interface IMoveDataLookup
    {
        public MoveData GetMoveData(string moveId);
    }
}
