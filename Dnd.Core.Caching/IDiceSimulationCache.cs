using Dnd.Application.Main.Models.Dice;

namespace Dnd.Core.Caching;

public interface IDiceSimulationCache
{
    void AddDiceSimulation(DiceSimulation diceSimulation);

    List<DiceSimulation> GetDiceSimulations();

    void RemoveDiceSimulation(DiceSimulation diceSimulation);

    void ClearDiceSimulations();
}