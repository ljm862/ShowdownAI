namespace ShowdownAI.Middleware.Models
{
    public class ActivePokemon
    {
        public List<MoveInfo> Moves { get; set; }
        public string CanTerastallize { get; set; }

        public static ActivePokemon DefaultActivePokemon()
        {
            var defaultMoveInfo = new MoveInfo()
            {
                Disabled = false,
                Id = "hit",
                Maxpp = 16,
                Method = AttackMethod.Physical,
                Move = "Hit",
                Power = 80,
                Pp = 16,
                Target = "normal",
                TargetType = TargetType.Normal,
                TypeName = TypeName.Water
            };
            return new ActivePokemon
            {
                Moves = new List<MoveInfo> { defaultMoveInfo, defaultMoveInfo, defaultMoveInfo, defaultMoveInfo },
                CanTerastallize = "Fire"
            };
        }
    }
}
