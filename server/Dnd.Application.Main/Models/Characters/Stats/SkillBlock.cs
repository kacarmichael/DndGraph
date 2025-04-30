using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Dnd.Application.Main.Models.Characters.Stats;

[ComplexType]
public class Skill
{
    public string Name { get; set; }
    public int Modifier { get; set; }
    public bool Proficient { get; set; }

    public Skill(string name, int modifier, bool proficient)
    {
        Name = name;
        Modifier = modifier;
        Proficient = proficient;
    }

    public Skill()
    {
        Name = "";
        Modifier = 0;
        Proficient = false;
    }

    public Skill(string name, int parentAbilityScore)
    {
        Name = name;
        Modifier = (parentAbilityScore - 10) / 2;
        Proficient = false;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Skill skill)
        {
            return this.Name == skill.Name;
        }

        return false;
    }

    public string ToJson() => JsonSerializer.Serialize(this);

    public int CompareTo(Object? obj)
    {
        if (obj is Skill)
        {
            Skill other = (Skill)obj;
            if (this.Modifier > other.Modifier)
            {
                return 1;
            }
            else if (this.Modifier < other.Modifier)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        throw new ArgumentException("Compared Object is not a skill");
    }
}

[ComplexType]
public class SkillBlock : IEnumerable<Skill>
{
    public Skill GetSkill(string skillName) => Skills.First((s) => s.Name == skillName);
    public List<Skill> Skills { get; set; }

    public SkillBlock()
    {
        Skills = new List<Skill>();
        foreach (var skill in Enum.GetValues(typeof(SkillName)))
        {
            Skills.Add(new Skill(skill.ToString(), 0, false));
        }
    }

    public SkillBlock(List<Skill> skills)
    {
        Skills = skills;
        foreach (var skill in Enum.GetValues(typeof(SkillName)))
        {
            if (!Skills.Exists(s => s.Name == skill.ToString()))
            {
                Skills.Add(new Skill(skill.ToString(), 0, false));
            }
        }
    }

    public SkillBlock(Dictionary<String, int> skills)
    {
        Skills = new List<Skill>();
        foreach (var skill in Enum.GetValues(typeof(SkillName)))
        {
            Skills.Add(new Skill(skill.ToString(), skills[skill.ToString()], false));
        }
    }

    public SkillBlock(Dictionary<String, int> skills, List<String> proficiencies)
    {
        Skills = new List<Skill>();
        foreach (var skill in Enum.GetValues(typeof(SkillName)))
        {
            Skills.Add(new Skill(skill.ToString(), skills[skill.ToString()], proficiencies.Contains(skill.ToString())));
        }
    }

    public SkillBlock(AbilityBlock abilities)
    {
        Skills = new List<Skill>();
        foreach (var ability in abilities)
        {
            foreach (var skill in ability.Skills)
            {
                Skills.Add(new Skill(skill, ability.Score ?? 0));
            }
        }
    }

    public IEnumerator<Skill> GetEnumerator()
    {
        return Skills.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public Dictionary<String, int> ToDictionary()
    {
        Dictionary<String, int> dict = new Dictionary<String, int>();
        foreach (var skill in Skills)
        {
            dict.Add(skill.Name, skill.Modifier);
        }

        return dict;
    }

    public override bool Equals(object? obj)
    {
        if (obj is SkillBlock block)
        {
            return this.Skills.Order().SequenceEqual(block.Skills.Order());
        }

        return false;
    }

    public string ToJson() => JsonSerializer.Serialize(this);
}