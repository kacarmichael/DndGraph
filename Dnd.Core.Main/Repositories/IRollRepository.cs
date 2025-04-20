namespace Dnd.Core.Main.Repositories;

public interface IRollRepository<T>
{
    public Task AddRoll(T roll);
    public Task AddRollAsync(T roll);
}