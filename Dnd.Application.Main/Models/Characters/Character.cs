//using dnd.apiModels.Rolls;

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters.Stats;

namespace Dnd.Application.Main.Models.Characters;

public class Character : ICharacter
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Name { get; set; }
    public int Level { get; set; }
    public int AC { get; set; }

    [JsonIgnore] public string? StatsJson { get; set; }

    [JsonIgnore] public string? ClassesJson { get; set; }

    [OnDeserialized]
    internal void OnDeserialized(StreamingContext context)
    {
        if (!string.IsNullOrEmpty(StatsJson))
            Stats = JsonSerializer.Deserialize<CharacterStats>(StatsJson);

        if (!string.IsNullOrEmpty(ClassesJson))
            Classes = JsonSerializer.Deserialize<Dictionary<string, int>>(ClassesJson);
    }

    [NotMapped]
    public ICharacterStats? Stats
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

    public Character(int id, string? name, int level, CharacterStats? stats, int ac, Dictionary<string, int>? charClass)
    {
        Id = id;
        Name = name;
        Level = level;
        Stats = stats;
        AC = ac;
        Classes = charClass;
    }

    public bool Equals(ICharacter? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id &&
               Name == other.Name &&
               Level == other.Level &&
               AC == other.AC &&
               Classes.Count == other.Classes.Count &&
               !Classes.Except(other.Classes).Any() &&
               Stats.Equals(other.Stats);
    }

    public static bool Compare(ICharacter character1, ICharacter character2)
    {
        return character1.Equals(character2);
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