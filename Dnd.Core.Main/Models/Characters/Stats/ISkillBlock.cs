namespace Dnd.Core.Main.Models.Characters.Stats;

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

public interface ISkill
{
    string name { get; set; }
    int modifier { get; set; }
    bool proficient { get; set; }
}

public interface ISkillBlock : IEnumerable<ISkill>
{
    SkillName GetSkill(string skillName);
    List<ISkill> Skills { get; set; }
    Dictionary<String, int> ToDictionary();
}