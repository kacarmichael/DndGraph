using System.Text.Json.Serialization;

namespace Dnd.Application.Main.Models.Dice;

public class SimResult
{
    [JsonPropertyName("value")] public int Value { get; set; }

    [JsonPropertyName("frequency")] public int Frequency { get; set; }
}