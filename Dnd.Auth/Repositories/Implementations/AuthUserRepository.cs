using Dnd.Auth.Infrastructure;
using Dnd.Auth.Models.Interfaces;
using Dnd.Auth.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Auth.Repositories.Implementations;

public class AuthUserRepository : IAuthUserRepository
{
    private readonly AuthDbContext _context;

    public AuthUserRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<IAuthUser> AddUserAsync(IAuthUser user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }
    
    public async Task<IAuthUser> GetUserAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
    }
    
    public async Task<IEnumerable<IAuthUser>> GetAllUsersAsync() => await _context.Users.ToListAsync();
    
    public async Task<Task> DeleteUserAsync(string username)
    {
        var user = await GetUserAsync(username);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return Task.CompletedTask;
    }
    
    public async Task<IAuthUser> UpdateUserAsync(IAuthUser user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }
}