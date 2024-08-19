using ShowdownAI.Middleware.Models;
using System.Text.Json;
using System.Reflection;


namespace ShowdownAI.Middleware.Services
{
    public class MoveDataLookup
    {
        private const string _moveDataPath = "./JsonMoveData/move_data.json";
        private readonly string _jsonData;    

        public MoveDataLookup()
        {
            _jsonData = File.ReadAllText(_moveDataPath);
        }

        public MoveData GetMoveData(string moveId)
        {
            MoveData moveData = new() { Id = moveId };

            using (JsonDocument document = JsonDocument.Parse(_jsonData))
            {
                JsonElement moves = document.RootElement.GetProperty("moves");

                foreach (JsonElement move in moves.EnumerateArray())
                {
                    if (move.TryGetProperty(moveId, out JsonElement moveAttributes))
                    {
                        foreach (JsonProperty moveAttribute in moveAttributes.EnumerateObject())
                        {
                            AddAttributeToMoveData(moveAttribute, moveData);
                        }
                    }
                }
            }

            return moveData;
        }

        private void AddAttributeToMoveData(JsonProperty moveAttribute, MoveData moveData) 
        {
            switch (moveAttribute.Name)
            {
                case "num":
                    moveData.Num = moveAttribute.Value.GetInt32();
                    break;
                case "accuracy":
                    // accuracy can be an int, or can be true denoting 100% accuracy
                    // currently set to int max value if true
                    // could chanage to be null or negative instead?
                    int accuracy;
                    bool isInt = moveAttribute.Value.TryGetInt32(out accuracy);
                    moveData.Accuracy = isInt ? accuracy : int.MaxValue;
                    break;
                case "basePower":
                    moveData.BasePower = moveAttribute.Value.GetInt32();
                    break;
                case "category":
                    string categoryString = moveAttribute.Value.GetString();
                    moveData.Method = (AttackMethod)Enum.Parse(typeof(AttackMethod), categoryString, ignoreCase: true);
                    break;
                case "name":
                    moveData.Name = moveAttribute.Value.GetString();
                    break;
                case "pp":
                    moveData.Pp = moveAttribute.Value.GetInt32();
                    break;
                case "priority":
                    moveData.Priority = moveAttribute.Value.GetInt32();
                    break;
                case "flags":
                    MoveFlags moveFlags = new();
                    foreach (JsonProperty flag in moveAttribute.Value.EnumerateObject())
                    {
                        moveFlags.GetType().GetProperty(flag.Name.Substring(0, 1).ToUpper() + flag.Name.Substring(1)).SetValue(moveFlags, true, null);
                    }
                    moveData.Flags = moveFlags;
                    break;
                case "target":
                    string targetString = moveAttribute.Value.GetString();
                    moveData.TargetType = (TargetType)Enum.Parse(typeof(TargetType), targetString, ignoreCase: true);
                    break;
                case "type":
                    string typeString = moveAttribute.Value.GetString();
                    moveData.Type = (TypeName)Enum.Parse(typeof(TypeName), typeString, ignoreCase: true);
                    break;
                case "isNonStandard":
                    moveData.IsNonStandard = moveAttribute.Value.GetString();
                    break;
                case "critRatio":
                    moveData.CritRatio = moveAttribute.Value.GetInt32();
                    break;
                case "secondary":
                    // needs implementing
                    break;
                default:
                    Console.WriteLine($"Attribute {moveAttribute.Name} not able to map");
                    break;
            }
        }
    }
}
