using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Application.Main.Utils;
using Dnd.Core.Main.Models.Characters;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Main.Models.Characters;

[NotMapped]
[PrimaryKey(propertyName: "ClassId")]
public class Class : IClass
{
    public int ClassId { get; set; }
    public string? SpellcastingAbility { get; set; }

    public string Name { get; set; }

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

        ClassId = -1;

        //ClassId = Array.IndexOf(Classes.AllClasses, Name);

        SpellcastingAbility = spellcastingAbility;
    }

    public Class(int id, string? spellcastingAbility, string? name)
    {
        Name = name;
        if (!Constants.AbilityNames.Contains(spellcastingAbility))
        {
            throw new ArgumentException("Invalid Spellcasting Ability");
        }

        ClassId = id;

        //ClassId = Array.IndexOf(Classes.AllClasses, Name);

        SpellcastingAbility = spellcastingAbility;
    }
}

public static class Classes
{
    public static readonly Class Barbarian = new Class(1, "Strength", "Barbarian");
    public static readonly Class Bard = new Class(2, "Charisma", "Bard");
    public static readonly Class Cleric = new Class(3, "Wisdom", "Cleric");
    public static readonly Class Druid = new Class(4, "Wisdom", "Druid");
    public static readonly Class Fighter = new Class(5, "Strength", "Fighter");
    public static readonly Class Monk = new Class(6, "Dexterity", "Monk");
    public static readonly Class Paladin = new Class(7, "Charisma", "Paladin");
    public static readonly Class Ranger = new Class(8, "Dexterity", "Ranger");
    public static readonly Class Rogue = new Class(9, "Dexterity", "Rogue");
    public static readonly Class Sorcerer = new Class(10, "Charisma", "Sorcerer");
    public static readonly Class Warlock = new Class(11, "Charisma", "Warlock");
    public static readonly Class Wizard = new Class(12, "Intelligence", "Wizard");
    public static readonly Class Artificer = new Class(13, "Intelligence", "Artificer");

    public static readonly Class[] AllClasses =
        { Barbarian, Bard, Cleric, Druid, Fighter, Monk, Paladin, Ranger, Rogue, Sorcerer, Warlock, Wizard, Artificer };

    public static Class GetClass(string className)
    {
        return AllClasses.First(x => x.Name == className);
    }
}