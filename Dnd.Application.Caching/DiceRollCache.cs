using Dnd.Core.Caching;
using Dnd.Core.Main;

namespace Dnd.Application.Caching;

public class DiceRollCache : IDiceRollCache
{
    private readonly List<IDiceRoll> _rolls = new();

    public void AddRoll(IDiceRoll roll)
    {
        _rolls.Add(roll);
    }

    public List<IDiceRoll> GetRolls()
    {
        return _rolls;
    }

    public void ClearRolls()
    {
        _rolls.Clear();
    }
}