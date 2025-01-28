using Dnd.API.Models.Dice.Implementations;
using Dnd.API.Models.Dice.Interfaces;
using Dnd.API.Models.Rolls.Interfaces;

namespace Dnd.API.Models.Rolls;

public class DiceSimulationFactory : IDiceSimulationFactory
{
    public IDiceSimulation CreateSimulation(IDiceSet diceSet, int numTrials)
    {
        return new DiceSimulation(simDice: diceSet, trials: numTrials);
    }
}