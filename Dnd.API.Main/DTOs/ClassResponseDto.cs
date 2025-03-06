using Dnd.Core.Main.Models.Characters;

namespace Dnd.API.Main.DTOs;

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