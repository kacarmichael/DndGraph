namespace Dnd.Core.Main.Models.Characters;

//TODO: Refactor ICharacterStats to include structs to hole values
public enum Ability
{
    Strength,
    Dexterity,
    Constitution,
    Intelligence,
    Wisdom,
    Charisma
}



public struct AbilityScores
{
    private readonly Dictionary<Ability, int> scores;

    public AbilityScores()
    {
        scores = new();
    }

    public int this[Ability ability]
    {
        get { return scores.TryGetValue(ability, out int modifier) ? modifier : 0; }
        set { scores[ability] = value; }
    }
}

