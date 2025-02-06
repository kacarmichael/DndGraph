using Dnd.API.Models.Characters.Interfaces;

namespace Dnd.API.DTOs;

public class ClassResponseDto
{
    public string Name { get; set; }
    public string SpellcastingAbility { get; set; }

    public ClassResponseDto(string name, string spellcastingAbility)
    {
        Name = name;
        SpellcastingAbility = spellcastingAbility;
    }

    public ClassResponseDto(IClass @class)
    {
        Name = @class.Name;
        SpellcastingAbility = @class.SpellcastingAbility;
    }
}