namespace Dnd.API.Models.Dice.Interfaces;

public interface ISimResult
{
    int Value { get; set; }
    int Frequency { get; set; }
}