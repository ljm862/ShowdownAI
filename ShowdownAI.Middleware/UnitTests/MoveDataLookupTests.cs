using KellermanSoftware.CompareNetObjects;
using ShowdownAI.Middleware.Models;
using ShowdownAI.Middleware.Services;

namespace UnitTests
{
    [TestClass]
    public class MoveDataLookupTests
    {
        // since accuracy comes in from the json file as either int or bool, test for both cases
        [TestMethod]
        public void MOVEDATALOOKUP_AccuracyIsBool_AccuracyGetsPopulatedAsInt()
        {
            MoveDataLookup moveLookup = new();
            string moveId = "10000000voltthunderbolt";

            MoveData moveData = moveLookup.GetMoveData(moveId);

            bool isInt = moveData.Accuracy is int;

            Assert.IsTrue(isInt);
        }

        [TestMethod]
        public void MOVEDATALOOKUP_AccuracyIsInt_AccuracyGetsPopulatedAsCorrectValue()
        {
            MoveDataLookup moveLookup = new();
            string moveId = "absorb";

            int expectedResult = 100;
            int returnedResult = moveLookup.GetMoveData(moveId).Accuracy;

            Assert.AreEqual(expectedResult, returnedResult);
        }


        // test moves with and without movew flags
        [TestMethod]
        public void MOVEDATALOOKUP_MoveWithoutMoveFlags_MoveDataIsCorrectlyPopulated()
        {
            MoveDataLookup dataLookup = new();
            string moveId = "oceanicoperetta";

            MoveData expectedResult = new()
            {
                Id = moveId,
                Num = 697,
                Accuracy = int.MaxValue, // may change from int.Max in future
                BasePower = 195,
                Method = AttackMethod.Special,
                Name = "Oceanic Operetta",
                Pp = 1,
                Priority = 0,
                Flags = new(),
                TargetType = TargetType.Normal,
                Type = TypeName.Water,
            };
            MoveData returnedResult = dataLookup.GetMoveData(moveId);

            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult result = compareLogic.Compare(expectedResult, returnedResult);

            Assert.IsTrue(result.AreEqual, message: result.DifferencesString);
        }

        [TestMethod]
        public void MOVEDATALOOKUP_MoveWithMoveFlags_MoveDataIsCorrectlyPopulated()
        {
            MoveDataLookup dataLookup = new();
            string moveId = "absorb";

            MoveData expectedResult = new()
            {
                Id = moveId,
                Accuracy = 100,
                BasePower = 20,
                Num = 71,
                Method = AttackMethod.Special,
                Name = "Absorb",
                Pp = 25,
                Priority = 0,
                Flags = new()
                {
                    Protect = true,
                    Mirror = true,
                    Heal = true,
                    Metronome = true,
                },
                TargetType = TargetType.Normal,
                Type = TypeName.Grass
            };
            MoveData returnedResult = dataLookup.GetMoveData(moveId);

            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult result = compareLogic.Compare(expectedResult, returnedResult);

            Assert.IsTrue(result.AreEqual, message: result.DifferencesString);
        }
    }
}
