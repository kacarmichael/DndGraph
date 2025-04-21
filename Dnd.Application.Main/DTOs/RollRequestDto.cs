using Dnd.Application.Main.Models.Dice;
using Dnd.Application.Main.Utils;

namespace Dnd.Application.Main.DTOs;

public class RollRequestDto : IDto
{
    public string RollType { get; set; }

    public string? Ability { get; set; }

    public int? CharacterId { get; set; }

    public int? Modifier { get; set; }

    public DiceSet DiceRolled { get; set; }

    public string? ClassUsed { get; set; }

    // [JsonIgnore] public Character? character { get; set; }

    public RollRequestDto(string rollType, string ability, int characterId, int? modifier, DiceSet diceRolled,
        string? classUsed)
    {
        RollType = rollType;
        Ability = ability;
        CharacterId = characterId;
        Modifier = modifier;
        DiceRolled = diceRolled;
        ClassUsed = classUsed;
    }
}