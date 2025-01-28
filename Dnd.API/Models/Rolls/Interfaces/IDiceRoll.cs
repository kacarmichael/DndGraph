using Dnd.API.Models.Characters.Interfaces;
using Dnd.API.Models.Dice.Interfaces;

namespace Dnd.API.Models.Rolls.Interfaces;

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