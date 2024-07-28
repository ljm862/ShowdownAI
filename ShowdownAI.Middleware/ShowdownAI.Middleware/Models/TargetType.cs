namespace ShowdownAI.Middleware.Models
{
    public enum TargetType
    {
        None,

        // single-target
        Normal,
        Any,
        AdjacentAlly,
        AdjacentFoe,
        AdjacentAllyOrSelf,

        // single-target, automatic
        Self,
        RandomNormal,

        // spread
        AllAdjacent,
        AllAdjacentFoes,

        // side and field
        AllySide,
        FoeSide,
        All
    }
}
