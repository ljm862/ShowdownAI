using ShowdownAI.Middleware.Models;

namespace ShowdownAI.Middleware.Services.Interfaces
{
    public interface ITypeLookup
    {
        public (TypeName, TypeName?) GetTypeData(string pokemonName);
    }
}
