using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Repositories;

namespace Dnd.Roll.API.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _repository;

    public CharacterService(ICharacterRepository repository)
    {
        _repository = repository;
    }

    public Character GetCharacterById(int id) => _repository.GetCharacter(id);

    public IEnumerable<Character> GetAllCharacters() => _repository.GetAllCharacters();

    public IEnumerable<Character> GetCurrentCharacters() => throw new NotImplementedException();
    
    public Class GetClassUsed(string className) => Constants.Classes[className];
}