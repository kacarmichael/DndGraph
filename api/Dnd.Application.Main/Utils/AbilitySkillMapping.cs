﻿namespace Dnd.Application.Main.Utils;

public class AbilitySkillMapping
{
    public static Dictionary<string, List<string>> Mapping = new Dictionary<string, List<string>>
    {
        ["Strength"] = new List<string> { "Athletics" },
        ["Dexterity"] = new List<string> { "Acrobatics", "Stealth", "SleightOfHand" },
        ["Intelligence"] = new List<string> { "Arcana", "History", "Investigation", "Nature", "Religion" },
        ["Wisdom"] = new List<string> { "AnimalHandling", "Insight", "Medicine", "Perception", "Survival" },
        ["Charisma"] = new List<string> { "Deception", "Intimidation", "Performance", "Persuasion" },
        ["Constitution"] = new List<string>()
    };
}