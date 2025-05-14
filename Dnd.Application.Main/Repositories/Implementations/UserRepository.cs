using Dnd.Application.Main.Infrastructure;
using Dnd.Application.Main.Infrastructure.Database;
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

    public async Task<DomainUser> GetUserByIdAsync(int userId)
    {
        return await Task.FromResult(_context.Users.Find(userId));
    }

    public async Task<DomainUser> AddUserAsync(DomainUser domainUser)
    {
        var res = _context.Users.Add(domainUser);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<DomainUser> UpdateUserAsync(DomainUser domainUser)
    {
        var res = _context.Users.Update(domainUser);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<DomainUser> DeleteUserAsync(DomainUser domainUser)
    {
        var res = _context.Users.Remove(domainUser);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<List<DomainUser>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<DomainUser> GetUserAsync(string username)
    {
        return await Task.FromResult(_context.Users.FirstOrDefault(x => x.Username == username));
    }
}