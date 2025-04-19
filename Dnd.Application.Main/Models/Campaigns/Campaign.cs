using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Application.Main.Models.Intermediate;
using Dnd.Core.Main.Models.Campaigns;
using Dnd.Core.Main.Models.Users;

namespace Dnd.Application.Main.Models.Campaigns;

public class Campaign : ICampaign
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    [NotMapped] public virtual List<IDomainUser> Players { get; set; }

    public int OwnerId { get; set; }

    [NotMapped] public virtual IDomainUser Owner { get; set; }

    public int DungeonMasterId { get; set; }

    [NotMapped] public virtual IDomainUser DungeonMaster { get; set; }

    [NotMapped] public virtual List<UserCharacterCampaign> UserCharacters { get; set; }

    public Campaign()
    {
    }

    public Campaign(string campaignName, List<IDomainUser> players, IDomainUser dungeonMaster, IDomainUser owner)
    {
        Name = campaignName;
        Players = players;
        DungeonMaster = dungeonMaster;
        Owner = owner;
    }
}