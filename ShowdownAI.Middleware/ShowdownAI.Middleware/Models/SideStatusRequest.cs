namespace ShowdownAI.Middleware.Models
{
    public class SideStatusRequest
    {
        public List<ActivePokemon> Active { get; set; }
        public Side Side { get; set; }
        public int Rqid { get; set; }
    }
}
