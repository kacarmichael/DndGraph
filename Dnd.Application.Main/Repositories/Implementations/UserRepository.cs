using Dnd.Application.Main.Infrastructure;
using Dnd.Application.Main.Models.Users;
using Dnd.Application.Main.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Main.Repositories.Implementations;

public class UserRepository : IUserRepository<DomainUser>
{
    private readonly DndDbContext _context;

    public UserRepository(DndDbContext context)
    {
        _context = context;
    }

    public Task<DomainUser> GetUserByIdAsync(int userId) => Task.FromResult(_context.Users.Find(userId));

    public Task<DomainUser> AddUserAsync(DomainUser domainUser) =>
        Task.FromResult(_context.Users.Add(domainUser).Entity);

    public Task<DomainUser> UpdateUserAsync(DomainUser domainUser) =>
        Task.FromResult(_context.Users.Update(domainUser).Entity);

    public Task<DomainUser> DeleteUserAsync(DomainUser domainUser) =>
        Task.FromResult(_context.Users.Remove(domainUser).Entity);

    public Task<List<DomainUser>> GetAllUsersAsync() =>
        _context.Users.ToListAsync();

    public Task<DomainUser> GetUserAsync(string username) =>
        Task.FromResult(_context.Users.FirstOrDefault(x => x.Username == username));
}