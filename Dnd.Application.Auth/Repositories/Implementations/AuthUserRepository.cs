using Dnd.Application.Auth.Infrastructure.Database;
using Dnd.Application.Auth.Models;
using Dnd.Application.Auth.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Auth.Repositories.Implementations;

public class AuthUserRepository : IAuthUserRepository
{
    private readonly AuthDbContext _context;

    public AuthUserRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<AuthUser> AddUserAsync(AuthUser user)
    {
        _context.AuthUsers.Add((AuthUser)user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<AuthUser> GetUserAsync(string username)
    {
        return await _context.AuthUsers.FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<IEnumerable<AuthUser>> GetAllUsersAsync() => await _context.AuthUsers.ToListAsync();

    public async Task<Task> DeleteUserAsync(string username)
    {
        var user = await GetUserAsync(username);
        _context.AuthUsers.Remove((AuthUser)user);
        await _context.SaveChangesAsync();
        return Task.CompletedTask;
    }

    public async Task<AuthUser> UpdateUserAsync(AuthUser user)
    {
        _context.AuthUsers.Update((AuthUser)user);
        await _context.SaveChangesAsync();
        return user;
    }
}