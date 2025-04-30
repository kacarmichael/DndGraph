using Dnd.Application.Main.Models.Rolls;
using Dnd.Application.Main.Utils;

namespace Dnd.Application.Main.DTOs;

public class RollResponseDto : IDto
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