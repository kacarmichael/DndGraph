using Dnd.Application.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Utils;

namespace Dnd.Application.Main.DTOs;

public class CharacterResponseDto : IDto
{
    public string Name { get; set; }
    public CharacterStats Stats { get; set; }
    public List<string> Proficiencies { get; set; }
    public int Level { get; set; }
    public int Ac { get; set; }

    public Dictionary<string, int> Classes { get; set; }

    public CharacterResponseDto()
    {
    }

    public CharacterResponseDto(ICharacter character)
    {
        Name = character.Name;
        Stats = (CharacterStats)character.Stats;
        Proficiencies = character.Stats.Proficiencies;
        Level = character.Level;
        Ac = character.AC;
        Classes = character.Classes;
    }

    public ICharacter DtoToCharacter()
    {
        return new Character(
            name: Name,
            level: Level,
            stats: Stats,
            ac: Ac,
            charClass: Classes
        );
    }
}