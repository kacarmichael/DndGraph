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

public interface IAbility
{
    string Name { get; set; }
    int? Score { get; set; }
    int Modifier { get; }
    bool Proficient { get; set; }
    private List<String> _skills
    {
        get { throw new NotImplementedException(); }
        set { throw new NotImplementedException(); }
    }
}

public interface IAbilityBlock : IEnumerable<IAbility>
{
    AbilityName GetAbility(string name);
    List<IAbility> Abilities { get; set; }
    Dictionary<String, int> ToDictionary();
}