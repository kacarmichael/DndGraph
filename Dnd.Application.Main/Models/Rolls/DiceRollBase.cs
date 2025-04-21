using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Dice;

namespace Dnd.Application.Main.Models.Rolls;

public abstract class DiceRollBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [NotMapped] public DiceSet DiceRolled { get; set; }

    [NotMapped] public Character? Roller { get; set; }
    public int Value { get; set; }

    public string RollType { get; set; }

    protected DiceRollBase()
    {
    }

    public virtual int Roll() => 0;

    public virtual string Describe() => "Dice Roll";
}