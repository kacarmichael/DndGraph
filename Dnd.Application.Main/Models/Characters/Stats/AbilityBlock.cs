using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Utils;

namespace Dnd.Application.Main.Models.Characters.Stats;

[ComplexType]
public class Ability : IAbility
{
    //public string Name { get; set; }
    public int? Score { get; set; }

    public int Modifier
    {
        get { return (Score - 10) / 2 ?? 0; }
    }

    public bool Proficient { get; set; }

    private List<String> _skills;
    private string _name;

    public List<String> Skills
    {
        get { return _skills; }
        set { _skills = value; }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            if (_name == "")
            {
                _skills = new List<String>();
            }
            else if (AbilitySkillMapping.Mapping.ContainsKey(_name))
            {
                _skills = AbilitySkillMapping.Mapping[_name];
            }
            else
            {
                throw new ArgumentException("Invalid Ability");
            }
        }
    }


    public Ability(string name, int score, bool proficient)
    {
        Name = name;
        Score = score;
        Proficient = proficient;
        _skills = AbilitySkillMapping.Mapping[name];
    }

    public Ability()
    {
        Name = "";
        Score = 0;
        Proficient = false;
        _skills = new List<String>();
    }

    public override string ToString()
    {
        return $"Ability - {this.Name}: {this.Score}";
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != typeof(Ability)) return false;
        Ability ability = (Ability)obj;
        return this.Name == ability.Name;
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }

    public int CompareTo(Object? obj)
    {
        if (obj is IAbility)
        {
            IAbility other = (IAbility)obj;
            if (this.Score > other.Score)
            {
                return 1;
            }
            else if (this.Score < other.Score)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        throw new ArgumentException("Compared Object is not an Ability");
    }
}

[ComplexType]
public class AbilityBlock : IAbilityBlock, IEnumerable<IAbility>
{
    public IAbility GetAbility(string name) => Abilities.First(a => a.Name == name);

    public List<IAbility> Abilities { get; set; }

    public AbilityBlock()
    {
        Abilities = new List<IAbility>();
        foreach (var ability in Enum.GetValues(typeof(AbilityName)))
        {
            Abilities.Add(new Ability(ability.ToString(), 10, false));
        }
    }

    public int Strength => Abilities.First(a => a.Name == this.GetAbility("Strength").ToString()).Score ?? 0;
    public int Dexterity => Abilities.First(a => a.Name == this.GetAbility("Dexterity").ToString()).Score ?? 0;
    public int Constitution => Abilities.First(a => a.Name == this.GetAbility("Constitution").ToString()).Score ?? 0;
    public int Intelligence => Abilities.First(a => a.Name == this.GetAbility("Intelligence").ToString()).Score ?? 0;
    public int Wisdom => Abilities.First(a => a.Name == this.GetAbility("Wisdom").ToString()).Score ?? 0;
    public int Charisma => Abilities.First(a => a.Name == this.GetAbility("Charisma").ToString()).Score ?? 0;


    public AbilityBlock(List<IAbility> abilities)
    {
        Abilities = abilities;
        foreach (var ability in Enum.GetValues(typeof(AbilityName)))
        {
            if (!Abilities.Exists(a => a.Name == ability.ToString()))
            {
                Abilities.Add(new Ability(ability.ToString(), 10, false));
            }
        }
    }

    public AbilityBlock(List<int> scores)
    {
        Abilities = new List<IAbility>();
        foreach (var ability in Enum.GetValues(typeof(AbilityName)))
        {
            Abilities.Add(new Ability(ability.ToString(),
                scores[Array.IndexOf(Enum.GetValues(typeof(AbilityName)), ability)], false));
        }
    }

    public AbilityBlock(Dictionary<String, int> dict)
    {
        Abilities = new List<IAbility>();
        foreach (var ability in Enum.GetValues(typeof(AbilityName)))
        {
            Abilities.Add(new Ability(ability.ToString(), dict[ability.ToString()], false));
        }
    }

    public AbilityBlock(Dictionary<String, int> dict, List<string> proficiencies)
    {
        Abilities = new List<IAbility>();
        foreach (var ability in Enum.GetValues(typeof(AbilityName)))
        {
            Abilities.Add(new Ability(ability.ToString(), dict[ability.ToString()],
                proficiencies.Contains(ability.ToString())));
        }
    }

    public IEnumerator<IAbility> GetEnumerator()
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
            dict.Add(ability.Name, ability.Score ?? 0);
        }

        return dict;
    }

    public override bool Equals(object? obj)
    {
        if (obj is AbilityBlock block)
        {
            return this.Abilities.Order().SequenceEqual(block.Abilities.Order());
        }

        return false;
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}