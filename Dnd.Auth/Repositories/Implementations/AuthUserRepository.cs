using Dnd.Auth.Infrastructure;
using Dnd.Auth.Models.Interfaces;
using Dnd.Auth.Repositories.Interfaces;

namespace Dnd.Auth.Repositories.Implementations;

public class AuthUserRepository : IAuthUserRepository
{
    private readonly AuthDbContext _context;

    public AuthUserRepository(AuthDbContext context)
    {
        _context = context;
    }

    public void AddUserAsync(IAuthUser user)
    {
    }
}