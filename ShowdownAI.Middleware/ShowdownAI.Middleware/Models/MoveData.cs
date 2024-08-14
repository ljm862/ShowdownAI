namespace ShowdownAI.Middleware.Models
{
    public class MoveData
    {
        // currently only has attributes that all moves share
        // possibly need to add nullable properties for other attributes
        public string Id { get; set; }
        public int Num { get; set; }    // move index number, used for Metronome rolls 
        public int Accuracy { get; set; }   // can be int or true which denotes 100% accuracy
        public int BasePower { get; set; }
        public AttackMethod Method { get; set; }
        public string Name { get; set; }
        public int Pp { get; set; }
        public int Priority { get; set; }
        public TargetType TargetType { get; set; }
        public TypeName Type { get; set; }
    }
}
