using System.Text.Json.Serialization;

namespace ShowdownAI.Middleware.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TypeName
    {
        None,
        Bug,
        Dark,
        Dragon,
        Electric,
        Fairy,
        Fighting,
        Fire,
        Flying,
        Ghost,
        Grass,
        Ground,
        Ice,
        Normal,
        Poison,
        Psychic,
        Rock,
        Steel,
        Stellar,
        Water,
    }
}
