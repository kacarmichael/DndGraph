using Dnd.Roll.API.Models.Rolls;

namespace Dnd.Roll.API.Repositories;

public interface IRollRepository
{
    public Task AddRoll(DiceRollBase roll);
    public Task AddRollAsync(DiceRollBase roll);
}