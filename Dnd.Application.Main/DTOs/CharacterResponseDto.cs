using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Intermediate;
using Dnd.Core.Main.Utils;

namespace Dnd.Application.Main.DTOs;

public class CharacterResponseDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int StatBlockId { get; set; }
    public Dictionary<String, int> Abilities { get; set; }
    public Dictionary<String, int> Skills { get; set; }
    public List<string> Proficiencies { get; set; }
    public int Level { get; set; }

    public Dictionary<int, int> Classes { get; set; }

    public CharacterResponseDto()
    {
    }

    // public CharacterResponseDto(ICharacter ch, List<ICharacterClass> cc, ICharacterStats cs)
    // {
    //     Id = ch.Id;
    //     Name = ch.Name;
    //     StatBlockId = ch.CharacterStatsId;
    //     (Abilities, Skills, Proficiencies) = cs.GetStatsDictionary();
    //     Level = cs.Level;
    //     Classes = cc.ToDictionary(cl => cl.ClassId, cl => cl.Levels);
    // }

    public CharacterResponseDto(ICharacter character, ICharacterStats stats, IEnumerable<ICharacterClass> classes)
    {
        Id = character.Id;
        Name = character.Name;
        StatBlockId = stats.StatBlockId;
        (Abilities, Skills, Proficiencies) = stats.GetStatsDictionary();
        Level = stats.Level;
        Classes = classes.ToDictionary(cl => cl.ClassId, cl => cl.Levels);
    }

    public CharacterResponseDto(ICharacter ch)
    {
        Id = ch.Id;
        Name = ch.Name;
        StatBlockId = ch.Stats.StatBlockId;
        (Abilities, Skills, Proficiencies) = ch.Stats.GetStatsDictionary();
        Level = ch.Stats.Level;
        Classes = ch.Classes.ToDictionary(cl => cl.ClassId, cl => cl.Levels);
    }
}