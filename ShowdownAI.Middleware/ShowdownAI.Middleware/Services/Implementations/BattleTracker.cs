using ShowdownAI.Middleware.Models;
using ShowdownAI.Middleware.Services.Interfaces;

namespace ShowdownAI.Middleware.Services.Implementations
{
    /// <summary>
    /// Acts as the memory part of the brain. Remembers which pokemon are on the field, which pokemon the opponent has that it has seen, items, moves, abilities, etc.
    /// </summary>
    public class BattleTracker : IBattleTracker
    {
        public List<Pokemon> OurTeam;
        public List<Pokemon> TheirTeam;

        public Pokemon OurCurrentPokemon;
        public Pokemon TheirCurrentPokemon;

        public ActivePokemon OurActivePokemon;

        public Weather Weather;

        public MoveInfo OurLastMove;
        public MoveInfo TheirLastMove;

        public MoveDataLookup MoveDataLookup;

        public BattleTracker()
        {
            OurTeam = new();
            TheirTeam = new();
            OurCurrentPokemon = new();
            TheirCurrentPokemon = new();
        }

        public ActivePokemon GetActivePokemon() => OurActivePokemon;
        public Pokemon GetOurCurrentPokemon() => OurCurrentPokemon;
        public Pokemon GetTheirCurrentPokemon() => TheirCurrentPokemon;

        public Weather GetCurrentWeather() => Weather;

        public void Update(string updateString)
        {
            // At some point this updateString will be a well defined class and updating will be simple. 
            // For now do some enough stuff to run a move prediction:

        }

        public void UpdateTurnStart(ActivePokemon ours, Pokemon ourActive, Pokemon theirs)
        {
            // Currently just enough to run a prediction
            OurActivePokemon = ours;
            OurCurrentPokemon = ourActive;
            TheirCurrentPokemon = theirs;
        }
    }
}
