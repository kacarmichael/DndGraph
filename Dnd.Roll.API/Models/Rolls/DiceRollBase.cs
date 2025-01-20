using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Roll.API.Models.Characters;

namespace Dnd.Roll.API.Models.Rolls;

public abstract class DiceRollBase
{
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    
    public Character? Roller { get; set; }
    public int Value { get; set; }
    
    public string RollType { get; set; }

    protected DiceRollBase()
    {
    }

    public virtual int Roll() => 0;

    public virtual string Describe() => "Dice Roll";
}