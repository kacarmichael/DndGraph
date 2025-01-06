namespace Dnd.Core.Characters;

public class CharacterStats
{
    public Dictionary<string, int> AbilityScores { get; set; }

    public Dictionary<string, int> AbilityModifiers { get; set; }
    public Dictionary<string, int> SkillModifiers { get; set; }

    public List<string> Proficiencies { get; set; }

    public CharacterStats(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma,
        int acrobatics, int animalHandling, int arcana, int athletics, int deception, int history, int insight,
        int intimidation, int investigation, int medicine, int nature, int perception, int performance, int persuasion,
        int religion, int sleightOfHand, int stealth, int survival, List<string> proficiencies)
    {
        AbilityScores = new Dictionary<string, int>()
        {
            { "Strength", strength },
            { "Dexterity", dexterity },
            { "Constitution", constitution },
            { "Intelligence", intelligence },
            { "Wisdom", wisdom },
            { "Charisma", charisma }
        };

        AbilityModifiers = new Dictionary<string, int>()
        {
            { "Strength", (strength - 10) / 2 },
            { "Dexterity", (dexterity - 10) / 2 },
            { "Constitution", (constitution - 10) / 2 },
            { "Intelligence", (intelligence - 10) / 2 },
            { "Wisdom", (wisdom - 10) / 2 },
            { "Charisma", (charisma - 10) / 2 }
        };

        Proficiencies = proficiencies;

        SkillModifiers = new Dictionary<string, int>()
        {
            { "Acrobatics", acrobatics },
            { "Animal Handling", animalHandling },
            { "Arcana", arcana },
            { "Athletics", athletics },
            { "Deception", deception },
            { "History", history },
            { "Insight", insight },
            { "Intimidation", intimidation },
            { "Investigation", investigation },
            { "Medicine", medicine },
            { "Nature", nature },
            { "Perception", perception },
            { "Performance", performance },
            { "Persuasion", persuasion },
            { "Religion", religion },
            { "Sleight of Hand", sleightOfHand },
            { "Stealth", stealth },
            { "Survival", survival }
        };
    }
}