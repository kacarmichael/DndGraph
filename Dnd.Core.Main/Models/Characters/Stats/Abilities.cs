using System.Collections;

namespace Dnd.Core.Main.Models.Characters.Stats;

//TODO: Refactor ICharacterStats to include structs to hole values


public class Ability
{
    public string name { get; set; }
    public int score { get; set; }
    public int modifier { get; set; }
    public bool proficient { get; set; }

    public List<String> Skills { get; set; }

    public Ability(string name, int score, int modifier, bool proficient)
    {
        this.name = name;
        this.score = score;
        this.modifier = (this.score - 10) / 2;
        this.proficient = proficient;
        this.Skills = AbilitySkillMapping.Mapping[name];
    }
}

public class AbilityBlock : IEnumerable<Ability>
{
    public enum AbilityName
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }
    
    public AbilityName GetAbility(string name) => (AbilityName)Enum.Parse(typeof(AbilityName), name);
    
    public List<Ability> Abilities { get; set; }

    public AbilityBlock()
    {
        Abilities = new List<Ability>();
        foreach (var ability in Enum.GetValues(typeof(AbilityName)))
        {
            Abilities.Add(new Ability(ability.ToString(), 10, 0, false));
        }
    }

    public AbilityBlock(List<Ability> abilities)
    {
        Abilities = abilities;
        foreach (var ability in Enum.GetValues(typeof(AbilityName)))
        {
            if (!Abilities.Exists(a => a.name == ability.ToString()))
            {
                Abilities.Add(new Ability(ability.ToString(), 10, 0, false));
            }
        }
    }
    
    public AbilityBlock(Dictionary<String, int> dict)
    {
        Abilities = new List<Ability>();
        foreach (var ability in Enum.GetValues(typeof(AbilityName)))
        {
            Abilities.Add(new Ability(ability.ToString(), dict[ability.ToString()], 0, false));
        }
    }
    
    public IEnumerator<Ability> GetEnumerator()
    {
        return Abilities.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public Dictionary<String, int> ToDictionary()
    {
        Dictionary<String, int> dict = new Dictionary<String, int>();
        foreach (var ability in Abilities)
        {
            dict.Add(ability.name, ability.score);
        }

        return dict;
    }
}