using Dnd.Application.Main.Models.Dice;

namespace Dnd.Application.Main.Caching.Interfaces;

public interface IDiceSimulationCache
{
    void AddDiceSimulation(DiceSimulation simulation);
    List<DiceSimulation> GetDiceSimulations();
    void RemoveDiceSimulation(DiceSimulation simulation);
    void ClearDiceSimulations();
}