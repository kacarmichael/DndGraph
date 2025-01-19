using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Models.Rolls;

namespace Dnd.Roll.API.DTOs;

public class RollRequestDto
{
    public string RollTYpe { get; set; }
    
    public string? Ability { get; set; }
    
    public int? CharacterId { get; set; }

    public static DiceRollBase DtoToRoll(RollRequestDto req)
    {
        switch (req.RollTYpe)
        {
            case "abilityCheck":
                return new AbilityCheckRoll(req.Ability, req.Character);
            case "savingThrow":
                return new SavingThrowRoll(req.Ability, req.Character);
            case "attackRollMelee":
                return new MeleeAttackRoll(req.Character);
            case "attackRollRanged":
                return new RangedAttackRoll(req.Character);
            default:
                throw new ArgumentException("Invalid Roll Type");
        }
    }

    public Character Character { get; set; }
}

