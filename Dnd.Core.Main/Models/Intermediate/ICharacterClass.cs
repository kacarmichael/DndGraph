using Dnd.Core.Main.Models.Characters;

namespace Dnd.Core.Main.Models.Intermediate;

public interface ICharacterClass
{
    int CharacterId { get; set; }
    ICharacter _character { get; set; }
    int ClassId { get; set; }
    IClass _class { get; set; }
    int Levels { get; set; }
}