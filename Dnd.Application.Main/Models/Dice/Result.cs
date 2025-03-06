using System.Text.Json.Serialization;
using Dnd.Core.Main.Models.Dice;

namespace Dnd.Application.Main.Models.Dice;

public class SimResult : ISimResult
{
    [JsonPropertyName("value")] public int Value { get; set; }

    [JsonPropertyName("frequency")] public int Frequency { get; set; }
}