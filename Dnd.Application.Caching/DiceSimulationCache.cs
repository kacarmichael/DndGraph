using Dnd.Core.Caching;
using Dnd.Core.Main;

namespace Dnd.Application.Caching;

public class DiceSimulationCache : IDiceSimulationCache
{
    private readonly List<IDiceSimulation> _cache = new();

    public void AddDiceSimulation(IDiceSimulation simulation)
    {
        _cache.Add(simulation);
    }

    public List<IDiceSimulation> GetDiceSimulations()
    {
        return _cache;
    }

    public void RemoveDiceSimulation(IDiceSimulation simulation)
    {
        _cache.Remove(simulation);
    }

    public void ClearDiceSimulations()
    {
        _cache.Clear();
    }
}