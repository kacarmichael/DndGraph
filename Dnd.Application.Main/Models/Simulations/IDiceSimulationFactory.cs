using Dnd.Application.Main.Models.Dice;

namespace Dnd.Application.Main.Models.Simulations;

public interface IDiceSimulationFactory
{
    DiceSimulation CreateSimulation(DiceSet diceSet, int numTrials, int modifier = 0);
}