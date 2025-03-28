using System.Collections;

namespace Dnd.Core.Main.Models.Characters.Stats;



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

public class SkillBlock : IEnumerable<Skill>
{
    public enum SkillName
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
    
    public SkillName GetSkill(string skillName) => (SkillName)Enum.Parse(typeof(SkillName), skillName);
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
            if (!Skills.Exists(s => s.name == skill.ToString()))
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
            dict.Add(skill.name, skill.modifier);
        }

        return dict;
    }
}
    

