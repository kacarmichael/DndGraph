using Dnd.API.Models.Characters;
using Dnd.API.Models.Characters.Implementations;
using Dnd.API.Models.Characters.Interfaces;
using CharacterStats = Dnd.API.Models.Characters.Implementations.CharacterStats;

namespace Dnd.API.DTOs;

public class CharacterResponseDto
{
    public string Name { get; set; }
    public CharacterStats Stats { get; set; }
    public List<string> Proficiencies { get; set; }
    public int Level { get; set; }
    public int Ac { get; set; }

    public Dictionary<string, int> Classes { get; set; }
    
    public CharacterResponseDto() { }

    public CharacterResponseDto(ICharacter character)
    {
        Name = character.Name;
        Stats = character.Stats;
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