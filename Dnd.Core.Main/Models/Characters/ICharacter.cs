using Dnd.Core.Main.Models.Characters.Stats;

namespace Dnd.Core.Main.Models.Characters;

public interface ICharacter
{
    int Id { get; set; }
    string Name { get; set; }
    int Level { get; set; }
    int AC { get; set; }
    //Dictionary<string, int> Classes { get; set; }
    ICharacterStats Stats { get; set; }
    int ProficiencyModifier => Level / 4 + 2;


    bool Equals(ICharacter? other);
    static bool Compare(ICharacter character1, ICharacter character2) => character1.Equals(character2);
}