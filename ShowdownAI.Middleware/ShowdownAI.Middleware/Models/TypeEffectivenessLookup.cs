namespace ShowdownAI.Middleware.Models
{
    public static class TypeEffectivenessLookup
    {
        // Dictionary follows the enum numerical values. For example, Electric is 4 in the enum
        // so slot of index 4 relates to Electric's effectiveness.
        public static Dictionary<TypeName, List<float>> Lookup = new()
        {
            //None, Bug, Dark, Dragon, Electric, Fairy, Fighting, Fire, Flying, Ghost, Grass, Ground, Ice, Normal, Poisn, Psychic, Rock ,Steel, Stellar, Water
            { TypeName.Bug, [0f,1f,2f,1f,1f,0.5f,0.5f,0.5f,0.5f,0.5f,2f,1f,1f,1f,0.5f,2f,1f,0.5f,1f,1f] },
            { TypeName.Dark, [0f,1f,0.5f,1f,1f,0.5f,0.5f,1f,1f,2f,1f,1f,1f,1f,1f,2f,1f,1f,1f,1f] },
            { TypeName.Dragon, [0f,1f,1f,2f,1f,0f,1f,1f,1f,1f,1f,1f,1f,1f,1f,1f,1f,0.5f,1f,1f] },
            { TypeName.Electric, [0f,1f,1f,0.5f,0.5f,1f,1f,1f,2f,1f,0.5f,0f,1f,1f,1f,1f,1f,1f,1f,2f] },
            { TypeName.Fairy, [0f,1f,2f,2f,1f,1f,2f,0.5f,1f,1f,1f,1f,1f,1f,0.5f,1f,1f,0.5f,1f,1f] },
            { TypeName.Fighting, [0f,0.5f,2f,1f,1f,0.5f,1f,1f,0.5f,0f,1f,1f,2f,2f,0.5f,0.5f,2f,2f,1f,1f] },
            { TypeName.Fire, [0f,2f,1f,0.5f,1f,1f,1f,0.5f,1f,1f,2f,1f,2f,1f,1f,1f,0.5f,2f,1f,0.5f] },
            { TypeName.Flying, [0f,2f,1f,1f,0.5f,1f,2f,1f,1f,1f,2f,1f,1f,1f,1f,1f,0.5f,0.5f,1f,1f] },
            { TypeName.Ghost, [0f,1f,0.5f,1f,1f,1f,1f,1f,1f,2f,1f,1f,1f,0f,1f,2f,1f,1f,1f,1f] },
            { TypeName.Grass, [0f,0.5f,1f,0.5f,1f,1f,1f,0.5f,0.5f,1f,0.5f,2f,1f,1f,0.5f,1f,2f,0.5f,1f,2f] },
            { TypeName.Ground, [0f,0.5f,1f,1f,2f,1f,1f,2f,0f,1f,0.5f,1f,1f,1f,2f,1f,2f,2f,1f,1f] },
            { TypeName.Ice, [0f,1f,1f,2f,1f,1f,1f,0.5f,2f,1f,2f,2f,0.5f,1f,1f,1f,1f,0.5f,1f,0.5f] },
            { TypeName.Normal, [0f,1f,1f,1f,1f,1f,1f,1f,1f,0f,1f,1f,1f,1f,1f,1f,0.5f,0.5f,1f,1f] },
            { TypeName.Poison, [0f,1f,1f,1f,1f,2f,1f,1f,1f,0.5f,2f,0.5f,1f,1f,0.5f,1f,1f,0f,1f,1f] },
            { TypeName.Psychic, [0f,1f,0f,1f,1f,1f,2f,1f,1f,1f,1f,1f,1f,1f,2f,0.5f,1f,0.5f,1f,1f] },
            { TypeName.Rock, [0f,2f,1f,1f,1f,1f,0.5f,2f,2f,1f,1f,0.5f,2f,1f,1f,1f,1f,0.5f,1f,1f] },
            { TypeName.Steel, [0f,1f,1f,1f,0.5f,2f,1f,0.5f,1f,1f,1f,1f,2f,1f,1f,1f,2f,0.5f,1f,0.5f] },
            { TypeName.Stellar, [0f,1f,1f,1f,1f,1f,1f,1f,1f,1f,1f,1f,1f,1f,1f,1f,1f,1f,1f,1f] },
            { TypeName.Water, [0f,1f,1f,0.5f,1f,1f,1f,2f,1f,1f,0.5f,2f,1f,1f,1f,1f,2f,1f,1f,0.5f] },
        };

        /// <summary>
        /// Quick test to check amounts are correct.
        /// </summary>
        /// <returns></returns>
        public static bool TestDictionary()
        {
            bool failed = false;
            int shouldBe = 20;
            foreach (var entry in Lookup)
            {
                int actual = Lookup[entry.Key].Count;
                if (actual != shouldBe)
                {
                    failed = true;
                    Console.WriteLine($"Failed on: {entry.Key}. Count of: {actual}");
                }
            }
            return failed;
        }
    }
}
