using Dnd.Application.Main.Models.Characters;
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
        AbilityScores = character.Stats.AbilityScores;
        SkillModifiers = character.Stats.SkillModifiers;
        Proficiencies = character.Stats.Proficiencies;
        Name = character.Name;
        Classes = character.Classes;
        Ac = character.AC;
        Level = character.Level;
    }

    public Character DtoToCharacter()
    {
        CharacterStats stats = new CharacterStats(
            AbilityScores["Strength"],
            AbilityScores["Dexterity"],
            AbilityScores["Constitution"],
            AbilityScores["Intelligence"],
            AbilityScores["Wisdom"],
            AbilityScores["Charisma"],
            SkillModifiers["Acrobatics"],
            SkillModifiers["AnimalHandling"],
            SkillModifiers["Arcana"],
            SkillModifiers["Athletics"],
            SkillModifiers["Deception"],
            SkillModifiers["History"],
            SkillModifiers["Insight"],
            SkillModifiers["Intimidation"],
            SkillModifiers["Investigation"],
            SkillModifiers["Medicine"],
            SkillModifiers["Nature"],
            SkillModifiers["Perception"],
            SkillModifiers["Performance"],
            SkillModifiers["Persuasion"],
            SkillModifiers["Religion"],
            SkillModifiers["SleightOfHand"],
            SkillModifiers["Stealth"],
            SkillModifiers["Survival"],
            Proficiencies);

        return new Character(Name, Level, stats, Ac, Classes);
    }
}