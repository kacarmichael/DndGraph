using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Dnd.Application.Main.Models.Characters.Stats;

namespace Dnd.Application.Main.Models.Characters;

[ComplexType]
public class CharacterStats
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StatBlockId { get; set; }

    [NotMapped] public virtual Character Character { get; set; }
    public int CharacterId { get; set; }
    public int Level { get; set; }

    [NotMapped] public virtual AbilityBlock Abilities { get; set; }

    [NotMapped] public virtual SkillBlock Skills { get; set; }
    public int ProficiencyBonus { get; set; }

    public int StrengthScore
    {
        get => Abilities.GetAbility("Strength").Score ?? 0;
        set => Abilities.GetAbility("Strength").Score = value;
    }

    public int DexterityScore
    {
        get => Abilities.GetAbility("Dexterity").Score ?? 0;
        set => Abilities.GetAbility("Dexterity").Score = value;
    }

    public int ConstitutionScore
    {
        get => Abilities.GetAbility("Constitution").Score ?? 0;
        set => Abilities.GetAbility("Constitution").Score = value;
    }

    public int IntelligenceScore
    {
        get => Abilities.GetAbility("Intelligence").Score ?? 0;
        set => Abilities.GetAbility("Intelligence").Score = value;
    }

    public int WisdomScore
    {
        get => Abilities.GetAbility("Wisdom").Score ?? 0;
        set => Abilities.GetAbility("Wisdom").Score = value;
    }

    public int CharismaScore
    {
        get => Abilities.GetAbility("Charisma").Score ?? 0;
        set => Abilities.GetAbility("Charisma").Score = value;
    }

    public CharacterStats()
    {
        Level = 1;
        Abilities = new AbilityBlock();
        Skills = new SkillBlock();
        ProficiencyBonus = (Level + 3) / 4 + 1;
    }

    public CharacterStats(int level, AbilityBlock abilities, SkillBlock skills)
    {
        Level = level;
        Abilities = abilities;
        Skills = skills;
        ProficiencyBonus = (Level + 3) / 4 + 1;
    }

    public CharacterStats(int level, AbilityBlock abilities)
    {
        Level = level;
        Abilities = abilities;
        Skills = new SkillBlock(abilities);
        ProficiencyBonus = (Level + 3) / 4 + 1;
    }

    public CharacterStats(int level, int characterId, AbilityBlock abilities)
    {
        Level = level;
        CharacterId = characterId;
        Abilities = abilities;
        Skills = new SkillBlock(abilities);
        ProficiencyBonus = (Level + 3) / 4 + 1;
    }

    public CharacterStats(int id, int characterId, int level, AbilityBlock abilities)
    {
        StatBlockId = id;
        CharacterId = characterId;
        Level = level;
        Abilities = abilities;
        Skills = new SkillBlock(abilities);
        ProficiencyBonus = (Level + 3) / 4 + 1;
    }

    public int AbilityCheckModifier(AbilityName abilityName)
    {
        Ability ability = Abilities.First(a => a.Name == abilityName.ToString());
        return (ability.Score ?? 0) + ability.Modifier + (ability.Proficient ? ProficiencyBonus : 0);
    }

    public int AbilityCheckModifier(string abilityName)
    {
        Ability ability = Abilities.First(a => a.Name == abilityName);
        return (ability.Score ?? 0) + ability.Modifier + (ability.Proficient ? ProficiencyBonus : 0);
    }

    public int SkillCheckModifier(SkillName skillName)
    {
        Skill skill = Skills.Skills.First(s => s.Name == skillName.ToString());
        return skill.Modifier + (skill.Proficient ? ProficiencyBonus : 0);
    }

    public int SkillCheckModifier(string skillName)
    {
        Skill skill = Skills.Skills.First(s => s.Name == skillName);
        return skill.Modifier + (skill.Proficient ? ProficiencyBonus : 0);
    }

    public int SaveThrowModifier(AbilityName abilityName)
    {
        Ability ability = Abilities.First(a => a.Name == abilityName.ToString());
        return (ability.Score ?? 0) + ability.Modifier + (ability.Proficient ? ProficiencyBonus : 0);
    }

    public int SaveThrowModifier(string abilityName)
    {
        Ability ability = Abilities.First(a => a.Name == abilityName);
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
        CharacterStats other = (CharacterStats)obj;
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