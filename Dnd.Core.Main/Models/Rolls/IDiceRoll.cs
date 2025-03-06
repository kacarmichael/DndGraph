using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Dice;

namespace Dnd.Core.Main.Models.Rolls;

public interface IDiceRoll
{
    int Id { get; set; }
    IDiceSet DiceRolled { get; set; }
    ICharacter? Roller { get; set; }
    int Value { get; set; }
    string RollType { get; set; }
    int Roll() => 0;
    string Describe() => "";
}