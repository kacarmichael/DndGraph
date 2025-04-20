namespace Dnd.Core.Main.Repositories;

public interface IUserRepository<T>
{
    Task<T> GetUserAsync(string username);
    Task<T> AddUserAsync(T domainUser);
    Task<T> UpdateUserAsync(T domainUser);
    Task<T> DeleteUserAsync(T domainUser);
    Task<List<T>> GetAllUsersAsync();
    Task<T> GetUserByIdAsync(int id);
}