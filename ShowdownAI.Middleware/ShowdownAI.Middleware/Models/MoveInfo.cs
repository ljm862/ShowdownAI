namespace ShowdownAI.Middleware.Models
{
    public class MoveInfo
    {
        public bool Disabled { get; set; }
        public string Id { get; set; }
        public AttackMethod Method { get; set; }
        public int Maxpp { get; set; }
        /// <summary>
        /// Name of the move
        /// </summary>
        public string Move { get; set; }
        public int Power { get; set; }
        public int Pp { get; set; }
        public string Target { get; set; }
        public TargetType TargetType { get; set; }
        public TypeName TypeName { get; set; }
    }
}
