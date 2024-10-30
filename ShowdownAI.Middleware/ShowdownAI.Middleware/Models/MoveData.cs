namespace ShowdownAI.Middleware.Models
{
    public class MoveData
    {
        public int Accuracy { get; set; }
        public int BasePower { get; set; }
        public int? CritRatio { get; set; }
        public MoveFlags Flags { get; set; }
        public string Id { get; set; }
        public string? IsNonStandard { get; set; }
        public AttackMethod Method { get; set; }
        public string Name { get; set; }
        public int Num { get; set; }    // move index number, used for Metronome rolls 
        public int Pp { get; set; }
        public int Priority { get; set; }
        public SecondaryEffect? Secondary { get; set; }
        public TargetType TargetType { get; set; }
        public TypeName Type { get; set; }
    }
}