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
    string name { get; set; }
    int score { get; set; }
    int modifier { get; set; }
    bool proficient { get; set; }
    List<String> Skills { get; set; }
}

public interface IAbilityBlock : IEnumerable<IAbility>
{
    AbilityName GetAbility(string name);
    List<IAbility> Abilities { get; set; }
    Dictionary<String, int> ToDictionary();
}