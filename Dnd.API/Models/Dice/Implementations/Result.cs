using System.Text.Json.Serialization;
using Dnd.API.Models.Dice.Interfaces;

namespace Dnd.API.Models.Dice.Implementations;

public class SimResult : ISimResult
{
    [JsonPropertyName("value")] public int Value { get; set; }

    [JsonPropertyName("frequency")] public int Frequency { get; set; }
}