using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Characters.Stats;

namespace Dnd.Application.Main.Models.Characters;

[ComplexType]
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
        ProficiencyBonus = (Level + 3) / 4 + 1;
    }

    public CharacterStats(int level, IAbilityBlock abilities, ISkillBlock skills)
    {
        Level = level;
        Abilities = abilities;
        Skills = skills;
        ProficiencyBonus = (Level + 3) / 4 + 1;
    }

    public int AbilityCheckModifier(AbilityName abilityName)
    {
        Ability ability = (Ability)Abilities.First(a => a.Name == abilityName.ToString());
        return (ability.Score ?? 0) + ability.Modifier + (ability.Proficient ? ProficiencyBonus : 0);
    }

    public int SkillCheckModifier(SkillName skillName)
    {
        Skill skill = (Skill)Skills.Skills.First(s => s.Name == skillName.ToString());
        return skill.Modifier + (skill.Proficient ? ProficiencyBonus : 0);
    }

    public int SaveThrowModifier(AbilityName abilityName)
    {
        Ability ability = (Ability)Abilities.First(a => a.Name == abilityName.ToString());
        return (ability.Score ?? 0) + ability.Modifier + (ability.Proficient ? ProficiencyBonus : 0);
    }

    // public bool Equals(ICharacterStats? other)
    // {
    //     if (ReferenceEquals(null, other)) return false;
    //     if (ReferenceEquals(this, other)) return true;
    //     return Level == other.Level && Abilities.Equals(other.Abilities) && Skills.Equals(other.Skills) &&
    //            ProficiencyBonus == other.ProficiencyBonus;
    // }

    public (Dictionary<String, int>, Dictionary<String, int>, List<String>) GetStatsDictionary()
    {
        List<String> proficiencies = new();
        foreach (var ability in Abilities.Abilities)
        {
            if (ability.Proficient)
            {
                proficiencies.Add(ability.Name);
            }
        }

        foreach (var skill in Skills.Skills)
        {
            if (skill.Proficient)
            {
                proficiencies.Add(skill.Name);
            }
        }

        return (Abilities.ToDictionary(), Skills.ToDictionary(), proficiencies);
    }
    
    public override bool Equals(object? obj)
    {
        ICharacterStats other = (ICharacterStats)obj;
        if (obj is CharacterStats stats)
        {
            return this.Abilities.Equals(other.Abilities) &&
                   this.Skills.Equals(other.Skills) &&
                   this.Level == other.Level &&
                   this.ProficiencyBonus == other.ProficiencyBonus;
        }

        return false;
    }
    
    public string ToJson() => JsonSerializer.Serialize(this);

    public override string ToString() => this.ToJson();
    
    public static CharacterStats FromJson(string json) => JsonSerializer.Deserialize<CharacterStats>(json)!;
}