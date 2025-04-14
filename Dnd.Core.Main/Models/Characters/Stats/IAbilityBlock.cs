namespace Dnd.Core.Main.Models.Characters.Stats;

public enum AbilityName
{
    Strength,
    Dexterity,
    Constitution,
    Intelligence,
    Wisdom,
    Charisma
}

public interface IAbility : IComparable
{
    string Name { get; set; }
    int? Score { get; set; }
    int Modifier { get; }
    bool Proficient { get; set; }

    List<String> Skills
    {
        get { throw new NotImplementedException(); }
        set { throw new NotImplementedException(); }
    }

    private List<String> _skills
    {
        get { throw new NotImplementedException(); }
        set { throw new NotImplementedException(); }
    }

    string ToJson();
}

public interface IAbilityBlock : IEnumerable<IAbility>
{
    IAbility GetAbility(string name);
    List<IAbility> Abilities { get; set; }
    Dictionary<String, int> ToDictionary();
    string ToJson();
}