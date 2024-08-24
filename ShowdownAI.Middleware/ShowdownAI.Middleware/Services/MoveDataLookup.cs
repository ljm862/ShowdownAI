using ShowdownAI.Middleware.Models;
using System.Text.Json;
using System.Reflection;


namespace ShowdownAI.Middleware.Services
{
    public class MoveDataLookup
    {
        private const string _moveDataPath = "./MoveData/move_data.json";
        private readonly string _jsonData;

        private Dictionary<string, MoveData> _moveData = new();

        public MoveDataLookup()
        {
            _jsonData = File.ReadAllText(_moveDataPath);
            GenerateMoveData();
        }

        public void GenerateMoveData()
        {
            using (JsonDocument document = JsonDocument.Parse(_jsonData))
            {
                JsonElement moves = document.RootElement.GetProperty("moves");

                foreach (JsonElement moveObject in moves.EnumerateArray())
                {
                    JsonProperty move = moveObject.EnumerateObject().FirstOrDefault();

                    MoveData moveData = new() { Id = move.Name };

                    foreach (JsonProperty moveAttribute in move.Value.EnumerateObject())
                    {
                        AddAttributeToMoveData(moveAttribute, moveData);
                    }

                    _moveData.Add(move.Name, moveData);
                }
            }
        }

        public MoveData GetMoveData(string moveId)
        {
            return _moveData[moveId];
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
                    // could change to be null or negative instead?
                    int accuracy;
                    try
                    {
                        accuracy = moveAttribute.Value.GetInt32();
                    }
                    catch (InvalidOperationException)
                    {
                        accuracy = int.MaxValue;
                    }
                    moveData.Accuracy = accuracy;
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
                    //Console.WriteLine($"Attribute {moveAttribute.Name} not able to map");
                    break;
            }
        }
    }
}
