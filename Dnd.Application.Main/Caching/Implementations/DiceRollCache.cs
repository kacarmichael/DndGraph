

using Dnd.Application.Main.Caching.Interfaces;
using Dnd.Application.Main.Models.Rolls;

namespace Dnd.Application.Main.Caching.Implementations;

public class DiceRollCache : IDiceRollCache
{
    private readonly List<DiceRollBase> _rolls = new();

    public void AddRoll(DiceRollBase roll)
    {
        _rolls.Add(roll);
    }

    public List<DiceRollBase> GetRolls()
    {
        return _rolls;
    }

    public void ClearRolls()
    {
        _rolls.Clear();
    }
}