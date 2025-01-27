using System.Text.Json.Serialization;
using Dnd.Roll.API.Models.Characters;

namespace Dnd.Roll.API.DTOs;

public class RollRequestDto
{
    public string RollType { get; set; }

    public string? Ability { get; set; }

    public int? CharacterId { get; set; }

    public int? Modifier { get; set; }

    public int? NumDice { get; set; }

    public int? NumSides { get; set; }

    public string? ClassUsed { get; set; }

    // [JsonIgnore] public Character? character { get; set; }

    public RollRequestDto(string rollType, string ability, int characterId, int? modifier, int? numDice, int? numSides, string? classUsed)
    {
        RollType = rollType;
        Ability = ability;
        CharacterId = characterId;
        Modifier = modifier;
        NumDice = numDice;
        NumSides = numSides;
        ClassUsed = classUsed;
    }
}