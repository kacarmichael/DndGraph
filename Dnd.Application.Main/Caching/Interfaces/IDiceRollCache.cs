using Dnd.Core.Main;

namespace Dnd.Core.Caching;

public interface IDiceRollCache
{
    //List<IDiceRoll> _rolls { get; set; }

    void AddRoll(IDiceRoll roll);
    List<IDiceRoll> GetRolls();
    void ClearRolls();
}