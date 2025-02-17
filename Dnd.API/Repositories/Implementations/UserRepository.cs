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