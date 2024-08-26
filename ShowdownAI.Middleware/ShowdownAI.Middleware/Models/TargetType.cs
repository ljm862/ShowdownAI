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
        Scripted,
        RandomNormal,

        // spread
        AllAdjacent,
        AllAdjacentFoes,

        // side and field
        Allies,
        AllyTeam,
        AllySide,
        FoeSide,
        All
    }
}
