using ShowdownAI.Middleware.Models;

namespace ShowdownAI.Middleware.Services
{
    /// <summary>
    /// Acts as the memory part of the brain. Remembers which pokemon are on the field, which pokemon the opponent has that it has seen, items, moves, abilities, etc.
    /// </summary>
    public class BattleTracker
    {
        public List<Pokemon> OurTeam;
        public List<Pokemon> TheirTeam;

        public Pokemon OurCurrentPokemon;
        public Pokemon TheirCurrentPokemon;

        public ActivePokemon OurActivePokemon;

        public BattleTracker()
        {
            OurTeam = new();
            TheirTeam = new();
            OurCurrentPokemon = new();
            TheirCurrentPokemon = new();
        }
    }
}
