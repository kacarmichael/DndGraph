using Dnd.Roll.API.Models.Characters;
using CharacterStats = Dnd.Roll.API.Models.Characters.CharacterStats;

namespace Dnd.Roll.API.DTOs;

public class CharacterResponseDto
{
    string Name { get; set; }
    CharacterStats Stats { get; set; }
    List<string> Proficiencies { get; set; }
    int Level { get; set; }
    int Ac { get; set; }

    Dictionary<string, int> Classes { get; set; }

    public CharacterResponseDto(Character character)
    {
        Name = character.Name;
        Stats = character.Stats;
        Proficiencies = character.Stats.Proficiencies;
        Level = character.Level;
        Ac = character.AC;
        Classes = character.Classes;
    }

    public Character DtoToCharacter()
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