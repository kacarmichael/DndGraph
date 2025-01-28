using System.ComponentModel.DataAnnotations.Schema;
using Dnd.API.Models.Characters.Interfaces;

namespace Dnd.API.Models.Characters.Implementations;

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