using System.Text.Json.Serialization;
using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Models.Rolls;

namespace Dnd.Roll.API.DTOs;

public class RollRequestDto
{
    public string RollType { get; set; }
    
    public string? Ability { get; set; }
    
    public int? CharacterId { get; set; }

    // public static DiceRollBase DtoToRoll(RollRequestDto req)
    // {
    //     switch (req.RollType)
    //     {
    //         case "abilityCheck":
    //             return new AbilityCheckRoll(req.Ability, req.character);
    //         case "savingThrow":
    //             return new SavingThrowRoll(req.Ability, req.character);
    //         case "attackRollMelee":
    //             return new MeleeAttackRoll(req.character);
    //         case "attackRollRanged":
    //             return new RangedAttackRoll(req.character);
    //         default:
    //             throw new ArgumentException("Invalid Roll Type");
    //     }
    // }
    
    [JsonIgnore]
    public Character? character { get; set; }
    
}

