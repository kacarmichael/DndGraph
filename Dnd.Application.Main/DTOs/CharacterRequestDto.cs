using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Utils;

namespace Dnd.Application.Main.DTOs;

public class CharacterRequestDto : IDto
{
    public Dictionary<string, int> AbilityScores { get; set; }
    //public Dictionary<string, int> SkillModifiers { get; set; }

    public List<string> Proficiencies { get; set; }

    public string Name { get; set; }
    public Dictionary<string, int> Classes { get; set; }
    //public int Ac { get; set; }

    public int Level { get; set; }

    public CharacterRequestDto()
    {
    }

    public CharacterRequestDto(Dictionary<string, int> abilityScores,
        Dictionary<string, int> skillModifiers,
        List<string> proficiencies,
        string name,
        Dictionary<string, int> classes,
        int ac)
    {
        AbilityScores = abilityScores;
        //SkillModifiers = skillModifiers;
        Proficiencies = proficiencies;
        Name = name;
        Classes = classes;
        //Ac = ac;
        Level = classes.Values.Sum();
    }

    public CharacterRequestDto(ICharacter character)
    {
        var (abilities, skills, proficiencies) = character.Stats.GetStatsDictionary();
        Name = character.Name;
        AbilityScores = abilities;
        Proficiencies = proficiencies;
        //Classes = character.Classes;
        //.Ac = character.AC;
        Level = character.Stats.Level;
    }

    //NOTE: Classes and Stats set to null to facilitate lazy loading
    // public ICharacter DtoToCharacter()
    // {
    //     return new Character(
    //         name: Name,
    //         charClass: null,
    //         //ac: Ac,
    //         stats: null
    //         );
    // }

    // public ICharacterStats DtoToCharacterStats()
    // {
    //     return new CharacterStats(
    //         level: Level,
    //         abilities: new AbilityBlock(AbilityScores));
    // }
}