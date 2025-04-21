using Dnd.Application.Main.Models.Dice;
using Dnd.Core.Caching;

namespace Dnd.Application.Caching;

public class DiceSimulationCache : IDiceSimulationCache
{
    private readonly List<DiceSimulation> _cache = new();

    public void AddDiceSimulation(DiceSimulation simulation)
    {
        _cache.Add(simulation);
    }

    public List<DiceSimulation> GetDiceSimulations()
    {
        return _cache;
    }

    public void RemoveDiceSimulation(DiceSimulation simulation)
    {
        _cache.Remove(simulation);
    }

    public void ClearDiceSimulations()
    {
        _cache.Clear();
    }
}