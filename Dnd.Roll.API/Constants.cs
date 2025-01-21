using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Models.Dice;

namespace Dnd.Roll.API;

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

    public static readonly Dictionary<string, Class?> Classes = new Dictionary<string, Class?>()
    {
        ["Bard"] = new("Charisma", "Bard"),
        ["Cleric"] = new("Wisdom", "Cleric"),
        ["Druid"] = new("Wisdom", "Druid"),
        ["Paladin"] = new("Charisma", "Paladin"),
        ["Ranger"] = new("Dexterity", "Ranger"),
        ["Sorcerer"] = new("Charisma", "Sorcerer"),
        ["Warlock"] = new("Charisma", "Warlock"),
        ["Wizard"] = new("Intelligence", "Wizard"),
    };
}