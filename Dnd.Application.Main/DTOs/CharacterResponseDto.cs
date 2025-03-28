using Dnd.Application.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Utils;

namespace Dnd.Application.Main.DTOs;

public class CharacterResponseDto : IDto
{
    public string Name { get; set; }
    public Dictionary<String, int> Abilities { get; set; }
    public Dictionary<String, int> Skills { get; set; }
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
        (Abilities, Skills, Proficiencies) = character.Stats.GetStatsDictionary();
        Level = character.Level;
        Ac = character.AC;
        Classes = character.Classes;
    }

    public ICharacter DtoToCharacter()
    {
        return new Character(
            name: Name,
            level: Level,
            stats: new CharacterStats(Level, new AbilityBlock(Abilities), new SkillBlock(Skills)),
            ac: Ac,
            charClass: Classes
        );
    }
}