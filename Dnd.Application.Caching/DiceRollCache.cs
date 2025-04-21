using Dnd.Application.Main.Models.Rolls;
using Dnd.Core.Caching;

namespace Dnd.Application.Caching;

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