using Dnd.Core.Dice;

namespace Dnd.Roll.API.Services;

public interface IRollService
{
    int Roll(int numDice, int numSides);
    int Roll(DiceSet set, int modifier = 0);
    int Roll(int numSides);
    
    void Simulate(int numDice, int numSides, int trials);
    void Simulate(DiceSet set, int trials);
    void Simulate(int numSides, int trials);
}