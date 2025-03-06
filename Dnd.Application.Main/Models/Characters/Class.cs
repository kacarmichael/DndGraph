using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Core.Main.Models.Characters;

namespace Dnd.Application.Main.Models.Characters;

[NotMapped]
public class Class : IClass
{
    public string? SpellcastingAbility { get; set; }

    public string? Name { get; set; }

    public Class()
    {
    }

    public Class(string? spellcastingAbility, string? name)
    {
        Name = name;
        if (!Constants.AbilityNames.Contains(spellcastingAbility))
        {
            throw new ArgumentException("Invalid Spellcasting Ability");
        }

        SpellcastingAbility = spellcastingAbility;
    }
}

public static class Classes
{
    public static readonly Class Barbarian = new Class("Strength", "Barbarian");
    public static readonly Class Bard = new Class("Charisma", "Bard");
    public static readonly Class Cleric = new Class("Wisdom", "Cleric");
    public static readonly Class Druid = new Class("Wisdom", "Druid");
    public static readonly Class Fighter = new Class("Strength", "Fighter");
    public static readonly Class Monk = new Class("Dexterity", "Monk");
    public static readonly Class Paladin = new Class("Charisma", "Paladin");
    public static readonly Class Ranger = new Class("Dexterity", "Ranger");
    public static readonly Class Rogue = new Class("Dexterity", "Rogue");
    public static readonly Class Sorcerer = new Class("Charisma", "Sorcerer");
    public static readonly Class Warlock = new Class("Charisma", "Warlock");
    public static readonly Class Wizard = new Class("Intelligence", "Wizard");
    public static readonly Class Artificer = new Class("Intelligence", "Artificer");

    public static readonly Class[] AllClasses =
        { Barbarian, Bard, Cleric, Druid, Fighter, Monk, Paladin, Ranger, Rogue, Sorcerer, Warlock, Wizard, Artificer };
}