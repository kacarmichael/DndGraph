using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Intermediate;
using Dnd.Core.Main.Models.Users;

namespace Dnd.Core.Main.Models.Characters;

public interface ICharacter
{
    int Id { get; set; }
    string Name { get; set; }

    //int CharacterStatsId { get; set; }
    ICharacterStats Stats { get; set; }

    int UserId { get; set; }
    IDomainUser User { get; set; }
    IEnumerable<ICharacterClass> Classes { get; set; }
    bool Equals(ICharacter? other);
    static bool Compare(ICharacter character1, ICharacter character2) => character1.Equals(character2);
}