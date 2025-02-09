using Dnd.API.Models.Dice.Implementations;
using Dnd.API.Models.Dice.Interfaces;
using Dnd.API.Models.Rolls.Interfaces;

namespace Dnd.API.Models.Rolls.Implementations;

public class DiceSimulationFactory : IDiceSimulationFactory
{
    public IDiceSimulation CreateSimulation(IDiceSet diceSet, int numTrials, int modifier = 0)
    {
        return new DiceSimulation(simDice: diceSet, trials: numTrials, modifier: modifier);
    }
}