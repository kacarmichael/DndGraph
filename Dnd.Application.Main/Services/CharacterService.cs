using Dnd.Application.Main.DTOs;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Utils;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Intermediate;
using Dnd.Core.Main.Repositories;
using Dnd.Core.Main.Services;
using Dnd.Core.Main.Utils;

namespace Dnd.Application.Main.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _repository;

    public CharacterService(ICharacterRepository repository)
    {
        _repository = repository;
    }

    public async Task<IDto> GetCharacterAsync(int id)
    {
        var character = _repository.GetCharacterAsync(id).Result;
        var stats = _repository.GetStatBlockByIdAsync(id).Result;
        var classes = _repository.GetCharacterClassesByIdAsync(id).Result;
        var dto = new CharacterResponseDto(character, new List<ICharacterClass> { classes }, stats);
        return dto;
    }

    public async Task<IEnumerable<IDto>> GetAllCharactersAsync()
    {
        var chars = _repository.GetAllCharactersAsync().Result;
        var stats = _repository.GetAllStatBlocksAsync().Result;
        var classes = _repository.GetAllCharacterClassesAsync().Result;
        var dtos = new List<CharacterResponseDto> { };
        foreach (var ch in chars)
        {
            var statblock = stats.FirstOrDefault(sb => sb.CharacterId == ch.Id);
            var cls = classes.Where(cl => cl.CharacterId == ch.Id).ToList();
            dtos.Add(new CharacterResponseDto(ch: ch, cc: cls, cs: statblock));
        }

        return dtos;
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