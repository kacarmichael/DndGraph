using Dnd.Core.Main.Utils;

namespace Dnd.Core.Main.Models.Characters;

public interface ICharacterStats
{
    List<Ability> Abilities { get; set; }
    
    List<string>? Proficiencies { get; set; }

    bool Equals(ICharacterStats? other);
    static bool Compare(ICharacterStats character1, ICharacterStats character2) => character1.Equals(character2);
}