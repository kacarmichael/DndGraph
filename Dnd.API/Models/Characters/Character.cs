//using Dnd.API.Models.Rolls;

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dnd.Roll.API.Models.Characters;

public class Character
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Name { get; set; }
    public int Level { get; set; }
    public int AC { get; set; }

    [JsonIgnore] public string? StatsJson { get; set; }

    [JsonIgnore] public string? ClassesJson { get; set; }

    [NotMapped]
    public CharacterStats? Stats
    {
        get => JsonSerializer.Deserialize<CharacterStats>(StatsJson);
        set => StatsJson = JsonSerializer.Serialize(value);
    }

    [NotMapped]
    public Dictionary<string, int>? Classes
    {
        get => JsonSerializer.Deserialize<Dictionary<string, int>>(ClassesJson);
        set => ClassesJson = JsonSerializer.Serialize(value);
    }

    public int ProficiencyModifier => Level / 4 + 2;

    public Character()
    {
    }

    public Character(string? name, int level, CharacterStats? stats, int ac, Dictionary<string, int>? charClass)
    {
        Name = name;
        Level = level;
        Stats = stats;
        AC = ac;
        Classes = charClass;
    }

//     public int Check(string ability) => new AbilityCheckRoll(ability, this).Roll();
//
//     public int SavingThrow(string ability) => new SavingThrowRoll(ability, this).Roll();
//
//     public int MeleeAttack() => new MeleeAttackRoll(this).Roll();
//
//     public int RangedAttack() => new RangedAttackRoll(this).Roll();
//
//     public int SpellAttack() => new SpellAttackRoll(this).Roll();
}