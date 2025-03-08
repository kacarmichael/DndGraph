using Dnd.Application.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters;

namespace Dnd.Application.Main.Utils;

public static class Constants
{
    public static readonly List<int> DiceSideValues = [4, 6, 8, 10, 12, 20, 100];

    public static readonly List<string?> AbilityNames =
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

    public static readonly Dictionary<string, IClass?> Classes = new Dictionary<string, IClass?>()
    {
        ["Bard"] = new Class("Charisma", "Bard"),
        ["Cleric"] = new Class("Wisdom", "Cleric"),
        ["Druid"] = new Class("Wisdom", "Druid"),
        ["Paladin"] = new Class("Charisma", "Paladin"),
        ["Ranger"] = new Class("Dexterity", "Ranger"),
        ["Sorcerer"] = new Class("Charisma", "Sorcerer"),
        ["Warlock"] = new Class("Charisma", "Warlock"),
        ["Wizard"] = new Class("Intelligence", "Wizard"),
    };
}