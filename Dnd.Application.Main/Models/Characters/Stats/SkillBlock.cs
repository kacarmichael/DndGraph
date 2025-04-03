using System.Collections;
using Dnd.Core.Main.Models.Characters.Stats;

namespace Dnd.Application.Main.Models.Characters.Stats;

public class Skill : ISkill
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
}

public class SkillBlock : ISkillBlock, IEnumerable<ISkill>
{
    public SkillName GetSkill(string skillName) => (SkillName)Enum.Parse(typeof(SkillName), skillName);
    public List<ISkill> Skills { get; set; }

    public SkillBlock()
    {
        Skills = new List<ISkill>();
        foreach (var skill in Enum.GetValues(typeof(SkillName)))
        {
            Skills.Add(new Skill(skill.ToString(), 0, false));
        }
    }

    public SkillBlock(List<ISkill> skills)
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
        Skills = new List<ISkill>();
        foreach (var skill in Enum.GetValues(typeof(SkillName)))
        {
            Skills.Add(new Skill(skill.ToString(), skills[skill.ToString()], false));
        }
    }
    
    public SkillBlock(Dictionary<String, int> skills, List<String> proficiencies)
    {
        Skills = new List<ISkill>();
        foreach (var skill in Enum.GetValues(typeof(SkillName)))
        {
            Skills.Add(new Skill(skill.ToString(), skills[skill.ToString()], proficiencies.Contains(skill.ToString())));
        }
    }

    public IEnumerator<ISkill> GetEnumerator()
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
}