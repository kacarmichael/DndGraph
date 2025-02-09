using Dnd.API.Models.Dice.Interfaces;

namespace Dnd.API.Models.Rolls.Interfaces;

public interface IDiceSimulationFactory
{
    IDiceSimulation CreateSimulation(IDiceSet diceSet, int trials, int modifier);
}