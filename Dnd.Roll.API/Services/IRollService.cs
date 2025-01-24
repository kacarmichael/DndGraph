using Dnd.Roll.API.DTOs;
using Dnd.Roll.API.Models.Dice;

namespace Dnd.Roll.API.Services;

public interface IRollService
{
    int Roll(int numDice, int numSides);
    int Roll(DiceSet set, int modifier = 0);
    int Roll(int numSides);
    RollResponseDto Roll(RollRequestDto req);

    DiceSimulation Simulate(int numDice, int numSides, int trials);
    DiceSimulation Simulate(DiceSet set, int trials);
    DiceSimulation Simulate(int numSides, int trials);
}