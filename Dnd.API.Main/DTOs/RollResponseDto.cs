using Dnd.Core.Main.Models.Rolls;

namespace Dnd.API.Main.DTOs;

public class RollResponseDto
{
    public string RollType { get; set; }
    public int RollValue { get; set; }
    public int? CharacterId { get; set; }
    public string? CharacterName { get; set; }

    public RollResponseDto(IDiceRoll Roll)
    {
        RollType = Roll.RollType;
        RollValue = Roll.Value;
        CharacterId = Roll.Roller?.Id;
        CharacterName = Roll.Roller?.Name;
    }
}