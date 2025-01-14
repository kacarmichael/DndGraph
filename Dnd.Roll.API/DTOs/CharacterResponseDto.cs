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
    
    public CharacterResponseDto(Character character)
    {
        Name = character.Name;
        Stats = character.Stats;
        Proficiencies = character.Stats.Proficiencies;
        Level = character.Level;
        Ac = character.AC;
    }
}