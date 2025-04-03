using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Utils;

namespace Dnd.Application.Main.DTOs;

public class CharacterRequestDto : IDto
{
    public Dictionary<string, int> AbilityScores { get; set; }
    public Dictionary<string, int> SkillModifiers { get; set; }

    public List<string> Proficiencies { get; set; }

    public string Name { get; set; }
    public Dictionary<string, int> Classes { get; set; }
    public int Ac { get; set; }

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
        SkillModifiers = skillModifiers;
        Proficiencies = proficiencies;
        Name = name;
        Classes = classes;
        Ac = ac;
        Level = classes.Values.Sum();
    }

    public CharacterRequestDto(ICharacter character)
    {
        (AbilityScores, SkillModifiers, Proficiencies) = character.Stats.GetStatsDictionary();
        Name = character.Name;
        Classes = character.Classes;
        Ac = character.AC;
        Level = character.Level;
    }

    public Character DtoToCharacter()
    {
        return new Character(
            name: Name,
            level: Level,
            charClass: Classes,
            ac: Ac,
            stats: new CharacterStats(
                level: Level,
                abilities: new AbilityBlock(AbilityScores, Proficiencies),
                skills: new SkillBlock(SkillModifiers, Proficiencies)
            ));
    }
}