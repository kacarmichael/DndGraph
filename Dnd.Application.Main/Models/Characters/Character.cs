//using dnd.apiModels.Rolls;

using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Application.Main.Models.Intermediate;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Intermediate;
using Dnd.Core.Main.Models.Users;

namespace Dnd.Application.Main.Models.Characters;

public class Character : ICharacter
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    //public int CharacterStatsId { get; set; }

    [NotMapped] public virtual ICharacterStats Stats { get; set; }

    public int UserId { get; set; }

    [NotMapped] public virtual IDomainUser User { get; set; }

    [NotMapped] public virtual List<UserCharacterCampaign> Campaigns { get; set; }

    [NotMapped] public virtual IEnumerable<ICharacterClass> Classes { get; set; }

    public Character()
    {
    }

    public Character(string name, ICharacterStats stats, Dictionary<string, int>? charClass)
    {
        Name = name;
        Stats = stats;
    }

    public Character(int id, string name, ICharacterStats stats, Dictionary<string, int>? charClass)
    {
        Id = id;
        Name = name;
        Stats = stats;
        //CharacterStatsId = stats.StatBlockId;
    }

    public Character(int id, string name, ICharacterStats stats, Dictionary<int, int>? charClass, int userId)
    {
        Id = id;
        Name = name;
        Stats = stats;
        //Classes = charClass;
        //CharacterStatsId = stats.StatBlockId;
        UserId = userId;
    }

    public Character(int id, string name, ICharacterStats stats, List<ICharacterClass> charClass, int userId)
    {
        Id = id;
        Name = name;
        Stats = stats;
        //CharacterStatsId = stats.StatBlockId;
        UserId = userId;
        Classes = charClass.Select(cc => (CharacterClass)cc).ToList();
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