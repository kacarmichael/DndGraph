using Dnd.Core.Characters;

namespace Dnd.Core;

public static class Constants
{
    public static readonly List<int> DiceSideValues = [4, 6, 8, 10, 12, 20, 100];

    public static readonly List<string> AbilityNames =
    [
        "Strength", "Dexterity", "Constitution", "Intelligence",
        "Wisdom", "Charisma"
    ];

    public static readonly List<string> SkillNames =
    [
        "Acrobatics", "Animal Handling", "Arcana", "Athletics", "Deception",
        "History", "Insight", "Intimidation", "Investigation", "Medicine", "Nature", "Perception", "Religion",
        "Sleight of Hand", "Stealth", "Survival"
    ];

    public static readonly Dictionary<string, Class> Classes = new Dictionary<string, Class>()
    {
        ["Bard"] = new("Charisma"),
        ["Cleric"] = new("Wisdom"),
        ["Druid"] = new("Wisdom"),
        ["Paladin"] = new("Charisma"),
        ["Ranger"] = new("Dexterity"),
        ["Sorcerer"] = new("Charisma"),
        ["Warlock"] = new("Charisma"),
        ["Wizard"] = new("Intelligence"),
    };
}