using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Characters.Stats;

namespace Dnd.Application.Main.Models.Characters;

public class CharacterStats : ICharacterStats
{
    public int Level { get; set; }
    public IAbilityBlock Abilities { get; set; }
    public ISkillBlock Skills { get; set; }
    public int ProficiencyBonus { get; set; }

    public CharacterStats()
    {
        Level = 1;
        Abilities = new AbilityBlock();
        Skills = new SkillBlock();
        ProficiencyBonus = 2;
    }

    public CharacterStats(int level, AbilityBlock abilities, SkillBlock skills)
    {
        Level = level;
        Abilities = abilities;
        Skills = skills;
        ProficiencyBonus = (Level + 3) / 4 + 1;
    }

    public int AbilityCheckModifier(AbilityName abilityName)
    {
        Ability ability = (Ability)Abilities.First(a => a.name == abilityName.ToString());
        return ability.score + ability.modifier + (ability.proficient ? ProficiencyBonus : 0);
    }

    public int SkillCheckModifier(SkillName skillName)
    {
        Skill skill = (Skill)Skills.Skills.First(s => s.name == skillName.ToString());
        return skill.modifier + (skill.proficient ? ProficiencyBonus : 0);
    }

    public int SaveThrowModifier(AbilityName abilityName)
    {
        Ability ability = (Ability)Abilities.First(a => a.name == abilityName.ToString());
        return ability.score + ability.modifier + (ability.proficient ? ProficiencyBonus : 0);
    }

    public bool Equals(ICharacterStats? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Level == other.Level && Abilities.Equals(other.Abilities) && Skills.Equals(other.Skills) &&
               ProficiencyBonus == other.ProficiencyBonus;
    }

    public (Dictionary<String, int>, Dictionary<String, int>, List<String>) GetStatsDictionary()
    {
        List<String> proficiencies = new();
        foreach (var ability in Abilities.Abilities)
        {
            if (ability.proficient)
            {
                proficiencies.Add(ability.name);
            }
        }

        foreach (var skill in Skills.Skills)
        {
            if (skill.proficient)
            {
                proficiencies.Add(skill.name);
            }
        }

        return (Abilities.ToDictionary(), Skills.ToDictionary(), proficiencies);
    }
}