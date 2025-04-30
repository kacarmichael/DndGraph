namespace Dnd.Application.Main.Repositories.Interfaces;

public interface IRollRepository<T>
{
    public Task AddRoll(T roll);
    public Task AddRollAsync(T roll);
}