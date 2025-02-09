using Dnd.API.DTOs;
using Dnd.API.Models.Dice.Interfaces;

namespace Dnd.API.Services.Interfaces;

public interface IRollService
{
    Task<RollResponseDto> Roll(RollRequestDto req);

    Task<IDiceSimulation> Simulate(IDiceSet set, int trials);

    DiceSimulationResponseDto Simulate(DiceSimulationRequestDto req);

    DiceRollResponseDto DiceRoll(DiceRollRequestDto req);
}