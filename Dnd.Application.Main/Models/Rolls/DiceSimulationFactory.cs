using Dnd.Application.Main.Models.Dice;
using Dnd.Core.Main.Models.Dice;
using Dnd.Core.Main.Models.Rolls;

namespace Dnd.Application.Main.Models.Rolls;

public class DiceSimulationFactory : IDiceSimulationFactory
{
    public IDiceSimulation CreateSimulation(IDiceSet diceSet, int numTrials, int modifier = 0)
    {
        return new DiceSimulation(simDice: diceSet, trials: numTrials, modifier: modifier);
    }
}