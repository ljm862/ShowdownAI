namespace ShowdownAI.Middleware.Models
{
    public class MoveInfo
    {
        /// <summary>
        /// Name of the move
        /// </summary>
        public string Move { get; set; }
        public string Id { get; set; }
        public int Pp { get; set; }
        public int Maxpp { get; set; }
        public string Target { get; set; }
        public TargetType TargetType { get; set; }
        public bool Disabled { get; set; }
    }
}
