using Dnd.API.Models.Characters;
using Dnd.API.Models.Characters.Implementations;
using Dnd.API.Models.Characters.Interfaces;
using Dnd.API.Models.Dice;
using Dnd.API.Models.Dice.Implementations;

namespace Dnd.API;

public static class Constants
{
    public static readonly List<int> DiceSideValues = [4, 6, 8, 10, 12, 20, 100];

    public static Dictionary<int, Die> DiceTypeSides = new()
    {
        { 4, Dice.D4 },
        { 6, Dice.D6 },
        { 8, Dice.D8 },
        { 10, Dice.D10 },
        { 12, Dice.D12 },
        { 20, Dice.D20 },
        { 100, Dice.D100 }
    };

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