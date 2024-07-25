namespace ShowdownAI.Middleware.Models
{
    public enum TargetType
    {
        None,

        // single-target
        normal,
        any,
        adjacentAlly,
        adjacentFoe,
        adjacentAllyOrSelf,

        // single-target, automatic
        self,
        randomNormal,

        // spread
	    allAdjacent,
        allAdjacentFoes,

        // side and field
        allySide,
        foeSide,
        all 
    }
}
