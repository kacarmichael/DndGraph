using Dnd.Core.Characters;
using Dnd.Core.Dice;

namespace Dnd.Core.Rolls;

public class MeleeAttackRoll(Character character) : IDiceRoll
{
    public int Roll()
    {
        return new DiceSet(1, 20).Roll() + character.Stats.AbilityModifiers["Strength"] + character.ProficiencyModifier;
    }

    public string Describe() => character.Name + " Melee Attack";
}

public class RangedAttackRoll(Character character) : IDiceRoll
{
    public int Roll()
    {
        return new DiceSet(1, 20).Roll() + character.Stats.AbilityModifiers["Dexterity"] +
               character.ProficiencyModifier;
    }

    public string Describe() => character.Name + " Melee Attack";
}