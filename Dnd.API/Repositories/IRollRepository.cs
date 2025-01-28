using Dnd.API.Models.Rolls;
using Dnd.API.Models.Rolls.Interfaces;

namespace Dnd.API.Repositories;

public interface IRollRepository
{
    public Task AddRoll(IDiceRoll roll);
    public Task AddRollAsync(IDiceRoll roll);
}