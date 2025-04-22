using Dnd.Application.Main.Models.Rolls;

namespace Dnd.Application.Main.Caching.Interfaces;

public interface IDiceRollCache
{
    void AddRoll(DiceRollBase roll);
    List<DiceRollBase> GetRolls();
    void ClearRolls();
}