using Dnd.API.Models.Rolls.Interfaces;

namespace Dnd.API.Repositories.Interfaces;

public interface IRollRepository
{
    public Task AddRoll(IDiceRoll roll);
    public Task AddRollAsync(IDiceRoll roll);
}