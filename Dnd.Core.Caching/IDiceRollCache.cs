using Dnd.Core.Main.Models.Rolls;

namespace Dnd.Core.Caching;

public interface IDiceRollCache
{
    //List<IDiceRoll> _rolls { get; set; }

    void AddRoll(IDiceRoll roll);
    List<IDiceRoll> GetRolls();
    void ClearRolls();
}