using Dnd.Roll.API.Models.Rolls;

namespace Dnd.Roll.API.Repositories;

public interface IRollRepository
{
    Task<DiceRollBase> GetRollById(int id);
    Task AddRoll(DiceRollBase roll);
    Task DeleteRoll(int id);
    Task UpdateRoll(DiceRollBase roll);
}