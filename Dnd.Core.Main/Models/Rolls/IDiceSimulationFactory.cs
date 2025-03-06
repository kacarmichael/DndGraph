using Dnd.Core.Main.Models.Dice;

namespace Dnd.Core.Main.Models.Rolls;

public interface IDiceSimulationFactory
{
    IDiceSimulation CreateSimulation(IDiceSet diceSet, int trials, int modifier);
}