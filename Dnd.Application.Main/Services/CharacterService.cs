using Dnd.Application.Main.DTOs;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Application.Main.Models.Intermediate;
using Dnd.Application.Main.Utils;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Intermediate;
using Dnd.Core.Main.Repositories;
using Dnd.Core.Main.Services;
using Dnd.Core.Main.Utils;

namespace Dnd.Application.Main.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _repository;
    private readonly IClassMapperService _classMapperService;

    public CharacterService(ICharacterRepository repository, IClassMapperService classMapperService)
    {
        _repository = repository;
        _classMapperService = classMapperService;
    }

    public async Task<ICharacter> GetCharacterAsync(int id)
    {
        var character = await _repository.GetCharacterAsync(id);
        return character;
    }

    public async Task<IEnumerable<ICharacter>> GetAllCharactersAsync()
    {
        var chars = await _repository.GetAllCharactersAsync();
        return chars;
    }

    public IEnumerable<ICharacter> GetCurrentCharacters() => throw new NotImplementedException();

    public IClass GetClassUsed(string className) => Constants.Classes[className];

    public async Task<ICharacter> AddCharacterAsync(ICharacter character)
    {
        return await _repository.AddCharacterAsync(character);
    }

    public async Task<ICharacter> AddCharacterAsync(ICharacter character, ICharacterStats stats,
        IEnumerable<ICharacterClass> classes)
    {
        return await _repository.AddCharacterAsync(character);
    }

    public IEnumerable<IClass> GetAllClasses()
    {
        return Classes.AllClasses;
    }

    public async Task<IEnumerable<ICharacterStats>> GetAllStatBlocksAsync()
    {
        return await _repository.GetAllStatBlocksAsync();
    }

    public async Task<ICharacterStats> GetStatBlockByIdAsync(int id)
    {
        return await _repository.GetStatBlockByIdAsync(id);
    }

    public async Task<ICharacterStats> AddStatBlockAsync(ICharacterStats stats)
    {
        return await _repository.AddStatBlock(stats);
    }

    public async Task<IEnumerable<ICharacterClass>> GetAllCharacterClasses()
    {
        return await _repository.GetAllCharacterClassesAsync();
    }

    public async Task<IEnumerable<ICharacterClass>> GetCharacterClassesByIdAsync(int id)
    {
        return await _repository.GetCharacterClassesByIdAsync(id);
    }

    public async Task<IEnumerable<ICharacterClass>> AddCharacterClassesAsync(IEnumerable<ICharacterClass> classes)
    {
        return await _repository.AddCharacterClassesAsync(classes);
    }

    public ICharacter DtoToCharacter(IDto req)
    {
        if (req is CharacterRequestDto crd)
        {
            return new Character(
                name: crd.Name,
                charClass: null,
                stats: null
            );
        }
        else
        {
            throw new ArgumentException("DtoToCharacter takes one CharacterRequestDto as arg");
        }
    }

    public ICharacterStats DtoToCharacterStats(IDto req, int characterId)
    {
        if (req is CharacterRequestDto crd)
        {
            return new CharacterStats(
                level: crd.Level,
                characterId: characterId,
                abilities: new AbilityBlock(crd.AbilityScores));
        }
        else
        {
            throw new ArgumentException("DtoToCharacter takes one CharacterRequestDto as arg");
        }
    }

    public IEnumerable<ICharacterClass> DtoToCharacterClasses(IDto req, int characterId)
    {
        var class_list = new List<CharacterClass>();
        if (req is CharacterRequestDto crd)
        {
            foreach (var kvp in crd.Classes)
            {
                var cid = _classMapperService.Map(kvp.Key).ClassId;
                class_list.Add(new CharacterClass(cid, characterId, kvp.Value));
            }

            return class_list;
        }
        else
        {
            throw new ArgumentException("DtoToCharacter takes one CharacterRequestDto as arg");
        }
    }
}