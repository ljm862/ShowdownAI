using ShowdownAI.Middleware.Models;

namespace ShowdownAI.Middleware.Services.Interfaces
{
    public interface IBattleTracker
    {
        public ActivePokemon GetActivePokemon();
        public Pokemon GetOurCurrentPokemon();
        public Pokemon GetTheirCurrentPokemon();
        public void Update(string updateString);
        public void UpdateTurnStart(ActivePokemon ours, Pokemon ourActive, Pokemon theirs);
        public Weather GetCurrentWeather();
    }
}
