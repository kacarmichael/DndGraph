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

    public async Task<Character> GetCharacterAsync(int id) => await _repository.GetCharacterAsync(id);

    public async Task<IEnumerable<Character>> GetAllCharactersAsync()
    {
        return await _repository.GetAllCharactersAsync();
    }

    public IEnumerable<Character> GetCurrentCharacters() => throw new NotImplementedException();

    public Class GetClassUsed(string className) => Constants.Classes[className];
}