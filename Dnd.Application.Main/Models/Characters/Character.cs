//using dnd.apiModels.Rolls;

using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Application.Main.Models.Characters.Stats;
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

    //[JsonIgnore] public string? StatsJson { get; set; }

    //[JsonIgnore] public string? ClassesJson { get; set; }

    // [OnDeserialized]
    // internal void OnDeserialized(StreamingContext context)
    // {
    //     if (!string.IsNullOrEmpty(StatsJson))
    //         Stats = JsonSerializer.Deserialize<CharacterStats>(StatsJson);
    //
    //     if (!string.IsNullOrEmpty(ClassesJson))
    //         Classes = JsonSerializer.Deserialize<Dictionary<string, int>>(ClassesJson);
    // }

    // [NotMapped]
    // public ICharacterStats? Stats
    // {
    //     get => JsonSerializer.Deserialize<CharacterStats>(StatsJson);
    //     set => StatsJson = JsonSerializer.Serialize(value);
    // }

    public ICharacterStats Stats { get; set; }

    public int Strength
    {
        get => Stats.Abilities.GetAbility("Strength").Score ?? 0;
        set => Stats.Abilities.Abilities.First(a => a.Name == "Strength").Score = value;
    }

    public int Dexterity
    {
        get => Stats.Abilities.GetAbility("Dexterity").Score ?? 0;
        set => Stats.Abilities.Abilities.First(a => a.Name == "Dexterity").Score = value;
    }

    public int Constitution
    {
        get => Stats.Abilities.GetAbility("Constitution").Score ?? 0;
        set => Stats.Abilities.Abilities.First(a => a.Name == "Constitution").Score = value;
    }

    public int Intelligence
    {
        get => Stats.Abilities.GetAbility("Intelligence").Score ?? 0;
        set => Stats.Abilities.Abilities.First(a => a.Name == "Intelligence").Score = value;
    }

    public int Wisdom
    {
        get => Stats.Abilities.GetAbility("Wisdom").Score ?? 0;
        set => Stats.Abilities.Abilities.First(a => a.Name == "Wisdom").Score = value;
    }

    public int Charisma
    {
        get => Stats.Abilities.GetAbility("Charisma").Score ?? 0;
        set => Stats.Abilities.Abilities.First(a => a.Name == "Charisma").Score = value;
    }

    // [NotMapped]
    // public Dictionary<string, int>? Classes
    // {
    //     get => JsonSerializer.Deserialize<Dictionary<string, int>>(ClassesJson);
    //     set => ClassesJson = JsonSerializer.Serialize(value);
    // }

    //public Dictionary<string, int>? Classes { get; set; }

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
        //Classes = charClass;
    }

    public Character(int id, string? name, int level, CharacterStats? stats, int ac, Dictionary<string, int>? charClass)
    {
        Id = id;
        Name = name;
        Level = level;
        Stats = stats;
        AC = ac;
        //Classes = charClass;
    }

    public Character(int id, string? name, int level, int str, int dex, int con, int intt, int wis, int cha, int ac)
    {
        Id = id;
        Name = name;
        Level = level;
        Stats = new CharacterStats(level, new AbilityBlock(new List<int>() { str, dex, con, intt, wis, cha }),
            new SkillBlock());
        AC = ac;
    }

    public bool Equals(ICharacter? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id &&
               Name == other.Name &&
               Level == other.Level &&
               AC == other.AC &&
               //Classes.Count == other.Classes.Count &&
               //!Classes.Except(other.Classes).Any() &&
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