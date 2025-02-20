using Dnd.Auth.Models.Interfaces;

namespace Dnd.Auth.Repositories.Interfaces;

public interface IAuthUserRepository
{
    public void AddUserAsync(IAuthUser user);
}