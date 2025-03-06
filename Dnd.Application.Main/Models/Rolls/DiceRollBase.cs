using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Dice;
using Dnd.Core.Main.Models.Rolls;

namespace Dnd.Application.Main.Models.Rolls;

public abstract class DiceRollBase : IDiceRoll
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public IDiceSet DiceRolled { get; set; }
    public ICharacter? Roller { get; set; }
    public int Value { get; set; }

    public string RollType { get; set; }

    protected DiceRollBase()
    {
    }

    public virtual int Roll() => 0;

    public virtual string Describe() => "Dice Roll";
}