using Dnd.Core.Characters;
using Dnd.Core.Dice;

namespace Dnd.Core.Rolls;

public class SpellAttackRoll(Character character) : IDiceRoll
{
    public string Describe() => "Spell Attack";

    public int Roll()
    {
        return new DiceSet(1, 20).Roll() + character.Stats.AbilityModifiers[character.Class.SpellcastingAbility] +
               character.ProficiencyModifier;
    }
}