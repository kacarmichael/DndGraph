using Dnd.Roll.API.DTOs;
using Dnd.Roll.API.Models.Rolls;

namespace Dnd.Roll.API.Services;

public interface IRollMapperService
{
    public DiceRollBase Map(RollRequestDto req);
    
    public RollResponseDto Map(DiceRollBase diceRoll);
}