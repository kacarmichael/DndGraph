using Dnd.Core.Main;

namespace Dnd.Core.Caching;

public interface IDiceSimulationCache
{
    void AddDiceSimulation(IDiceSimulation diceSimulation);

    List<IDiceSimulation> GetDiceSimulations();

    void RemoveDiceSimulation(IDiceSimulation diceSimulation);

    void ClearDiceSimulations();
}