using System.ComponentModel.DataAnnotations.Schema;

namespace Dnd.Roll.API.Models.Rolls;

public abstract class DiceRollBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    //public Character? Roller { get; }
    public int Value;

    protected DiceRollBase()
    {
    }

    public virtual int Roll() => 0;

    public virtual string Describe() => "Dice Roll";
}