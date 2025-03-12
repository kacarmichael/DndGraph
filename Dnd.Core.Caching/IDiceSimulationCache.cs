using Dnd.Core.Main.Models.Dice;

namespace Dnd.Core.Caching;

public interface IDiceSimulationCache
{
    void AddDiceSimulation(IDiceSimulation diceSimulation);

    List<IDiceSimulation> GetDiceSimulations();

    void RemoveDiceSimulation(IDiceSimulation diceSimulation);

    void ClearDiceSimulations();
}