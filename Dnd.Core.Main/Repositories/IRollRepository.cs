using Dnd.Core.Main.Models.Rolls;

namespace Dnd.Core.Main.Repositories;

public interface IRollRepository
{
    public Task AddRoll(IDiceRoll roll);
    public Task AddRollAsync(IDiceRoll roll);
}