using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Intermediate;

namespace Dnd.Application.Main.Models.Intermediate;

public class CharacterClass : ICharacterClass
{
    public int CharacterId { get; set; }
    public int ClassId { get; set; }
    public int Levels { get; set; }

    [NotMapped] public ICharacter _character { get; set; }

    [NotMapped] public IClass _class { get; set; }

    public CharacterClass()
    {
    }

    public CharacterClass(int classId, int characterId, int levels)
    {
        ClassId = classId;
        CharacterId = characterId;
        Levels = levels;
    }
}