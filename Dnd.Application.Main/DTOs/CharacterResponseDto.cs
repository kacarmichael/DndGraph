using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Characters.Stats;
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
    //public int Ac { get; set; }

    public Dictionary<int, int> Classes { get; set; }

    public CharacterResponseDto()
    {
    }

    public CharacterResponseDto(ICharacter ch, List<ICharacterClass> cc, ICharacterStats cs)
    {
        Id = ch.Id;
        Name = ch.Name;
        StatBlockId = ch.CharacterStatsId;
        (Abilities, Skills, Proficiencies) = cs.GetStatsDictionary();
        Level = cs.Level;
        Classes = cc.ToDictionary(cl => cl.ClassId, cl => cl.Levels);
    }

    public Tuple<ICharacter, ICharacterClass, ICharacterStats> DtoToCharacter()
    {
        var cs = new CharacterStats(
            level: Level,
            abilities: new AbilityBlock(Abilities),
            id: StatBlockId,
            characterId: Id);
        var cl = new
            var ch = new Character(
            id: Id,
            name: Name,
            stats: cs
        );
    }
}