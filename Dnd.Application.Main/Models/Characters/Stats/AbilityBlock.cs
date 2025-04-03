using System.Collections;
using System.Runtime.InteropServices.JavaScript;
using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Utils;

namespace Dnd.Application.Main.Models.Characters.Stats;

public class Ability : IAbility
{
    //public string Name { get; set; }
    public int? Score { get; set; }

    public int Modifier 
    {
        get
        {
            return (this.Score - 10) / 2 ?? 0;
        }
    }
    public bool Proficient { get; set; }
    
    private List<String> _skills;
    private string _name;

    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            if (AbilitySkillMapping.Mapping.ContainsKey(_name))
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
}

public class AbilityBlock : IAbilityBlock, IEnumerable<IAbility>
{
    public AbilityName GetAbility(string name) => (AbilityName)Enum.Parse(typeof(AbilityName), name);

    public List<IAbility> Abilities { get; set; }

    public AbilityBlock()
    {
        Abilities = new List<IAbility>();
        foreach (var ability in Enum.GetValues(typeof(AbilityName)))
        {
            Abilities.Add(new Ability(ability.ToString(), 10, false));
        }
    }

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
            Abilities.Add(new Ability(ability.ToString(), dict[ability.ToString()], proficiencies.Contains(ability.ToString())));
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
}