using Dnd.Application.Main.Models.Dice;

namespace Dnd.Application.Main.Models.Rolls;

public interface IDiceSimulationFactory
{
    DiceSimulation CreateSimulation(DiceSet diceSet, int numTrials, int modifier = 0);
}