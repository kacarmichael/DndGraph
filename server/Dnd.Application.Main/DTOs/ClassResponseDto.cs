using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Utils;

namespace Dnd.Application.Main.DTOs;

public class ClassResponseDto : IDto
{
    public string Name { get; set; }
    public string SpellcastingAbility { get; set; }

    public ClassResponseDto(string name, string spellcastingAbility)
    {
        Name = name;
        SpellcastingAbility = spellcastingAbility;
    }

    public ClassResponseDto(Class @class)
    {
        Name = @class.Name;
        SpellcastingAbility = @class.SpellcastingAbility;
    }
}