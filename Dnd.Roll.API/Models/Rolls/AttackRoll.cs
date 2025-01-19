using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Models.Dice;

namespace Dnd.Roll.API.Models.Rolls;

public class MeleeAttackRoll : DiceRollBase
{
    public Character Roller { get; }

    public void Initialize() => Value = Roll();

    public MeleeAttackRoll(Character character)
    {
        Roller = character;
        Initialize();
    }

    public override int Roll()
    {
        return new DiceSet(1, 20).Roll() + Roller.Stats.AbilityModifiers["Strength"] + Roller.ProficiencyModifier;
    }

    public override string Describe() => Roller.Name + " Melee Attack";
}

public class RangedAttackRoll : DiceRollBase
{
    public Character Roller { get; }

    public void Initialize() => Value = Roll();

    public RangedAttackRoll(Character character)
    {
        Roller = character;
        Initialize();
    }

    public override int Roll()
    {
        return new DiceSet(1, 20).Roll() + Roller.Stats.AbilityModifiers["Dexterity"] +
               Roller.ProficiencyModifier;
    }

    public override string Describe() => Roller.Name + " Melee Attack";
}