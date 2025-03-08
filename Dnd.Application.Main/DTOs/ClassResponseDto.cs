using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Utils;

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

    public ClassResponseDto(IClass @class)
    {
        Name = @class.Name;
        SpellcastingAbility = @class.SpellcastingAbility;
    }
}