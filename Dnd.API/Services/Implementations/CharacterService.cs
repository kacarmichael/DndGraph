using Dnd.API.Models.Characters.Implementations;
using Dnd.API.Models.Characters.Interfaces;
using Dnd.API.Repositories;
using Dnd.API.Repositories.Interfaces;
using Dnd.API.Services.Interfaces;

namespace Dnd.API.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _repository;

    public CharacterService(ICharacterRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICharacter> GetCharacterAsync(int id) => await _repository.GetCharacterAsync(id);

    public async Task<IEnumerable<ICharacter>> GetAllCharactersAsync()
    {
        return await _repository.GetAllCharactersAsync();
    }

    public IEnumerable<ICharacter> GetCurrentCharacters() => throw new NotImplementedException();

    public IClass GetClassUsed(string className) => Constants.Classes[className];

    public async Task<ICharacter> AddCharacterAsync(ICharacter character)
    {
        return await _repository.AddCharacter(character);
    }

    public IEnumerable<IClass> GetAllClasses()
    {
        return Classes.AllClasses;
    }
}