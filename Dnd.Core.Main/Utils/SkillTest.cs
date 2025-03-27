namespace Dnd.Core.Main.Utils;

public static class AbilitySkillMapping
{
    public static Dictionary<string, List<string>> Mapping = new Dictionary<string, List<string>>
    {
        ["Strength"] = new List<string> { "Athletics" },
        ["Dexterity"] = new List<string> { "Acrobatics", "Stealth", "SleightOfHand" },
        ["Intelligence"] = new List<string> { "Arcana", "History", "Investigation", "Nature", "Religion" },
        ["Wisdom"] = new List<string> { "AnimalHandling","Insight", "Medicine", "Perception", "Survival" },
        ["Charisma"] = new List<string> { "Deception", "Intimidation", "Performance", "Persuasion"}
    };
}


public enum SkillEnum
{
    Acrobatics,
    AnimalHandling,
    Arcana,
    Athletics,
    Deception,
    History,
    Insight,
    Intimidation,
    Investigation,
    Medicine,
    Nature,
    Perception,
    Performance,
    Persuasion,
    Religion,
    SleightOfHand,
    Stealth,
    Survival
}

public enum AbilityEnum
{
    Strength,
    Dexterity,
    Constitution,
    Intelligence,
    Wisdom,
    Charisma
}

public class Skill
{
    public string name { get; set; }
    public int modifier { get; set; }
    public bool proficient { get; set; }
    
    public Skill(string name, int modifier, bool proficient)
    {
        this.name = name;
        this.modifier = modifier;
        this.proficient = proficient;
    }
}

public class Ability
{
    public string name { get; set; }
    public int score { get; set; }
    public int modifier { get; set; }
    public bool proficient { get; set; }
    
    public List<String> Skills { get; set; }

    public Ability(string name, int score, int modifier, bool proficient)
    {
        this.name = name;
        this.score = score;
        this.modifier = (this.score - 10) / 2;
        this.proficient = proficient;
        this.Skills = AbilitySkillMapping.Mapping[name];
    }
}

public class AbilityBlock
{
    public List<Ability> Abilities { get; set; }

    public AbilityBlock()
    {
        Abilities = new List<Ability>();
        foreach (var ability in Enum.GetValues(typeof(AbilityEnum)))
        {
            Abilities.Add(new Ability(ability.ToString(), 10, 0, false));
        }
    }
    
    public AbilityBlock(List<Ability> abilities)
    {
        Abilities = abilities;
        foreach (var ability in Enum.GetValues(typeof(AbilityEnum)))
        {
            if (!Abilities.Exists(a => a.name == ability.ToString()))
            {
                Abilities.Add(new Ability(ability.ToString(), 10, 0, false));
            }
        }
    }
}

public class SkillBlock
{
    public List<Skill> Skills { get; set; }
    public SkillBlock()
    {
        Skills = new List<Skill>();
        foreach (var skill in Enum.GetValues(typeof(SkillEnum)))
        {
            Skills.Add(new Skill(skill.ToString(), 0, false));
        }
    }
    
    public SkillBlock(List<Skill> skills)
    {
        Skills = skills;
        foreach (var skill in Enum.GetValues(typeof(SkillEnum)))
        {
            if (!Skills.Exists(s => s.name == skill.ToString()))
            {
                Skills.Add(new Skill(skill.ToString(), 0, false));
            }
        }
    }
}

public class StatBlock
{
    public int Level { get; set; }
    public AbilityBlock AbilityBlock { get; set; }
    public SkillBlock Skills { get; set; }
    public int ProficiencyBonus { get; set; }

    public StatBlock()
    {
        Level = 1;
        AbilityBlock = new AbilityBlock();
        Skills = new SkillBlock();
        ProficiencyBonus = 2;
    }
    
    public StatBlock(int level, AbilityBlock abilities, SkillBlock skills)
    {
        Level = level;
        AbilityBlock = abilities;
        Skills = skills;
        ProficiencyBonus = (Level + 3) / 4 + 1;
    }
    
    public int AbilityCheck(AbilityEnum ability)
    {
        Ability Ability = AbilityBlock.Abilities.First(a => a.name == ability.ToString());
        return Ability.score + Ability.modifier + (Ability.proficient ? ProficiencyBonus : 0);
    }
    
    public int SkillCheck(SkillEnum skill)
    {
        Skill Skill = Skills.Skills.First(s => s.name == skill.ToString());
        return Skill.modifier + (Skill.proficient ? ProficiencyBonus : 0);
    }
    
    public int SaveThrow(AbilityEnum ability)
    {
        Ability Ability = AbilityBlock.Abilities.First(a => a.name == ability.ToString());
        return Ability.score + Ability.modifier + (Ability.proficient ? ProficiencyBonus : 0);
    }
}

