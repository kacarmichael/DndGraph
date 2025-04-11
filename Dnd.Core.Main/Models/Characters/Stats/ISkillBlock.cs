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

public interface ISkill : IComparable
{
    string Name { get; set; }
    int Modifier { get; set; }
    bool Proficient { get; set; }
    string ToJson();
}

public interface ISkillBlock : IEnumerable<ISkill>
{
    SkillName GetSkill(string skillName);
    List<ISkill> Skills { get; set; }
    Dictionary<String, int> ToDictionary();
    string ToJson();
}