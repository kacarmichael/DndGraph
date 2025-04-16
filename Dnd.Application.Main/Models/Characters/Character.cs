//using dnd.apiModels.Rolls;

using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Application.Main.Models.Intermediate;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Users;

namespace Dnd.Application.Main.Models.Characters;

public class Character : ICharacter
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public int CharacterStatsId { get; set; }
    public ICharacterStats Stats { get; set; }

    public int UserId { get; set; }

    [NotMapped] public IDomainUser User { get; set; }

    // [NotMapped]
    // public List<ICharacterClass> Classes { get; set; }

    [NotMapped] public List<UserCharacterCampaign> Campaigns { get; set; }

    [NotMapped] public List<CharacterClass> Classes { get; set; }

    public Character()
    {
    }

    public Character(string name, int level, ICharacterStats stats, int ac, Dictionary<string, int>? charClass)
    {
        Name = name;
        Stats = stats;
    }

    public Character(int id, string name, int level, ICharacterStats stats, int ac, Dictionary<string, int>? charClass)
    {
        Id = id;
        Name = name;
        Stats = stats;
    }

    public Character(int id, string name, int level, int str, int dex, int con, int intt, int wis, int cha, int ac)
    {
        Id = id;
        Name = name;
        Stats = new CharacterStats(level, new AbilityBlock(new List<int>() { str, dex, con, intt, wis, cha }),
            new SkillBlock());
    }

    public Character(int id, string name, int level, IAbilityBlock abilities)
    {
        Id = id;
        Name = name;
        Stats = new CharacterStats(level, abilities);
    }

    public bool Equals(ICharacter? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id &&
               Name == other.Name &&
               Stats.Level == other.Stats.Level &&
               Stats.Equals(other.Stats);
    }

    public static bool Compare(ICharacter character1, ICharacter character2)
    {
        return character1.Equals(character2);
    }
}