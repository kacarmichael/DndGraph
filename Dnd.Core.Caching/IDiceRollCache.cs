using Dnd.Application.Main.Models.Rolls;

namespace Dnd.Core.Caching;

public interface IDiceRollCache
{
    //List<IDiceRoll> _rolls { get; set; }

    void AddRoll(DiceRollBase roll);
    List<DiceRollBase> GetRolls();
    void ClearRolls();
}