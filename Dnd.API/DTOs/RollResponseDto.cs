using Dnd.Roll.API.Models.Rolls;

namespace Dnd.Roll.API.DTOs;

public class RollResponseDto
{
    public string RollType { get; set; }
    public int RollValue { get; set; }
    public int? CharacterId { get; set; }
    public string? CharacterName { get; set; }

    public RollResponseDto(DiceRollBase Roll)
    {
        RollType = Roll.RollType;
        RollValue = Roll.Value;
        CharacterId = Roll.Roller?.Id;
        CharacterName = Roll.Roller?.Name;
    }
}