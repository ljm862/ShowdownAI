using ShowdownAI.Middleware.Models;
using ShowdownAI.Middleware.Services.Interfaces;

namespace ShowdownAI.Middleware.Services.Implementations
{
    public class TypeLookup : ITypeLookup
    {
        private const string _typeLookupPath = "./Models/Data/pokemon-data.csv";

        private Dictionary<string, (TypeName, TypeName?)> _typeData = new();

        public TypeLookup()
        {
            GenerateTypeData();
        }

        public (TypeName, TypeName?) GetTypeData(string pokemonName)
        {
            var success = _typeData.TryGetValue(pokemonName, out (TypeName, TypeName?) value);
            if (!success) Console.WriteLine($"Could not find move with id: {pokemonName}");
            return value;
        }

        private void GenerateTypeData()
        {
            using (var reader = new StreamReader(_typeLookupPath))
            {
                _ = reader.ReadLine(); // Reads header line and discards it
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',', StringSplitOptions.TrimEntries);

                    // Need to address different forms of pokemon where the same name isn't the same types
                    Enum.TryParse(typeof(TypeName), values[3], out var type1);
                    Enum.TryParse(typeof(TypeName), values[4], out var type2);

                    // Probably want to cache as lower case and retrieve as lower case
                    var success = _typeData.TryAdd(values[1], ((TypeName)type1, (TypeName?)type2));
                    if (!success) Console.WriteLine($"Could not add {values[1]} types to dictionary, do they already exist?");
                }
            }
        }
    }
}
