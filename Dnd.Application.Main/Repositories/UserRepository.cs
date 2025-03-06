using Dnd.Application.Main.Infrastructure;
using Dnd.Application.Main.Models.Users;
using Dnd.Core.Main.Models.Users;
using Dnd.Core.Main.Repositories;

namespace Dnd.Application.Main.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }

    public Task<IDomainUser> GetUserByIdAsync(int userId) => Task.FromResult((IDomainUser)_context.Users.Find(userId));

    public Task<IDomainUser> AddUserAsync(IDomainUser domainUser) =>
        Task.FromResult((IDomainUser)_context.Users.Add((DomainUser)domainUser).Entity);

    public Task<IDomainUser> UpdateUserAsync(IDomainUser domainUser) =>
        Task.FromResult((IDomainUser)_context.Users.Update((DomainUser)domainUser).Entity);

    public Task<IDomainUser> DeleteUserAsync(IDomainUser domainUser) =>
        Task.FromResult((IDomainUser)_context.Users.Remove((DomainUser)domainUser).Entity);

    public Task<IEnumerable<IDomainUser>> GetAllUsersAsync() =>
        Task.FromResult((IEnumerable<IDomainUser>)_context.Users);

    public Task<IDomainUser> GetUserAsync(string username) =>
        Task.FromResult((IDomainUser)_context.Users.FirstOrDefault(x => x.Username == username));
}