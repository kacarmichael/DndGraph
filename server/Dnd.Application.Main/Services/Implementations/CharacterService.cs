using Dnd.Application.Main.DTOs;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Application.Main.Models.Intermediate;
using Dnd.Application.Main.Repositories.Interfaces;
using Dnd.Application.Main.Services.Interfaces;
using Dnd.Application.Main.Utils;

namespace Dnd.Application.Main.Services.Implementations;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository<Character, CharacterStats, CharacterClass> _repository;
    private readonly IClassMapperService _classMapperService;

    public CharacterService(ICharacterRepository<Character, CharacterStats, CharacterClass> repository,
        IClassMapperService classMapperService)
    {
        _repository = repository;
        _classMapperService = classMapperService;
    }

    public async Task<Character> GetCharacterAsync(int id)
    {
        var character = await _repository.GetCharacterAsync(id);
        return character;
    }

    public async Task<IEnumerable<Character>> GetAllCharactersAsync()
    {
        var chars = await _repository.GetAllCharactersAsync();
        return chars;
    }

    public IEnumerable<Character> GetCurrentCharacters() => throw new NotImplementedException();

    public Class GetClassUsed(string className) => Constants.Classes[className];

    public async Task<Character> AddCharacterAsync(Character character)
    {
        var charImpl = character as Character;
        if (charImpl == null)
        {
            throw new ArgumentException("Invalid CampaignSession in Creation");
        }

        return await _repository.AddCharacterAsync(charImpl);
    }

    public async Task<Character> AddCharacterAsync(Character character, CharacterStats stats,
        IEnumerable<CharacterClass> classes)
    {
        var charImpl = character as Character;
        if (charImpl == null)
        {
            throw new ArgumentException("Invalid Character in Creation");
        }

        return await _repository.AddCharacterAsync(charImpl);
    }

    public IEnumerable<Class> GetAllClasses()
    {
        return Classes.AllClasses;
    }

    public async Task<IEnumerable<CharacterStats>> GetAllStatBlocksAsync()
    {
        return await _repository.GetAllStatBlocksAsync();
    }

    public async Task<CharacterStats> GetStatBlockByIdAsync(int id)
    {
        return await _repository.GetStatBlockByIdAsync(id);
    }

    public async Task<CharacterStats> AddStatBlockAsync(CharacterStats stats)
    {
        var statsImpl = stats as CharacterStats;
        if (statsImpl == null)
        {
            throw new ArgumentException("Invalid CharacterStats in Creation");
        }

        return await _repository.AddStatBlock(statsImpl);
    }

    public async Task<IEnumerable<CharacterClass>> GetAllCharacterClasses()
    {
        return await _repository.GetAllCharacterClassesAsync();
    }

    public async Task<IEnumerable<CharacterClass>> GetCharacterClassesByIdAsync(int id)
    {
        return await _repository.GetCharacterClassesByIdAsync(id);
    }

    public async Task<IEnumerable<CharacterClass>> AddCharacterClassesAsync(IEnumerable<CharacterClass> classes)
    {
        var classImpl = classes as IEnumerable<CharacterClass>;
        if (classImpl == null)
        {
            throw new ArgumentException("Invalid CampaignClasses in Creation");
        }

        return await _repository.AddCharacterClassesAsync(classImpl);
    }

    public Character DtoToCharacter(IDto req)
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

    public CharacterStats DtoToCharacterStats(IDto req, int characterId)
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

    public IEnumerable<CharacterClass> DtoToCharacterClasses(IDto req, int characterId)
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