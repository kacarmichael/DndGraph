namespace Dnd.API.Models.Dice.Interfaces;

public interface IDiceSet
{
    int NumDice { get; set; }
    int NumSides { get; set; }
    
    int Roll();
}