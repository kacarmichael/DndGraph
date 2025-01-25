using Dnd.Roll.API.DTOs;
using Dnd.Roll.API.Models.Dice;

namespace Dnd.Roll.API.Services;

public interface IRollService
{
    Task<RollResponseDto> Roll(RollRequestDto req);

    Task<DiceSimulation> Simulate(DiceSet set, int trials);
}