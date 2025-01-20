using Dnd.Roll.API.Models.Characters;

namespace Dnd.Roll.API.Repositories;

public interface ICharacterRepository
{
    Task<Character> GetCharacterById(int id);    
}