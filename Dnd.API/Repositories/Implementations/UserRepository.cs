using Dnd.API.Infrastructure;
using Dnd.API.Models.Users.Implementations;
using Dnd.API.Models.Users.Interfaces;
using Dnd.API.Repositories.Interfaces;

namespace Dnd.API.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }

    public Task<IUser> GetUserByIdAsync(int userId) => Task.FromResult((IUser)_context.Users.Find(userId));

    public Task<IUser> AddUserAsync(IUser user) => Task.FromResult((IUser)_context.Users.Add((User)user).Entity);

    public Task<IUser> UpdateUserAsync(IUser user) => Task.FromResult((IUser)_context.Users.Update((User)user).Entity);

    public Task<IUser> DeleteUserAsync(IUser user) => Task.FromResult((IUser)_context.Users.Remove((User)user).Entity);

    public Task<IEnumerable<IUser>> GetAllUsersAsync() => Task.FromResult((IEnumerable<IUser>)_context.Users);

    public Task<IUser> GetUserAsync(string username) =>
        Task.FromResult((IUser)_context.Users.FirstOrDefault(x => x.Username == username));
}