using Dnd.Application.Main.Models.Dice;

namespace Dnd.Application.Main.Models.Simulations;

public class DiceSimulationFactory : IDiceSimulationFactory
{
    public DiceSimulation CreateSimulation(DiceSet diceSet, int numTrials, int modifier = 0)
    {
        return new DiceSimulation(simDice: diceSet, trials: numTrials, modifier: modifier);
    }
}