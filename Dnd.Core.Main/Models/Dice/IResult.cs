namespace Dnd.Core.Main.Models.Dice;

public interface ISimResult
{
    int Value { get; set; }
    int Frequency { get; set; }
}