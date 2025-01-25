using System.ComponentModel.DataAnnotations.Schema;

namespace Dnd.Roll.API.Models.Characters;

[NotMapped]
public class Class
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