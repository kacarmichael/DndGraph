using System.ComponentModel.DataAnnotations.Schema;
using Dnd.API.Models.Characters.Interfaces;
using Dnd.API.Models.Dice.Interfaces;
using Dnd.API.Models.Rolls.Interfaces;

namespace Dnd.API.Models.Rolls.Implementations;

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