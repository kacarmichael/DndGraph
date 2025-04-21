using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Application.Main.Models.Intermediate;
using Dnd.Application.Main.Models.Users;

namespace Dnd.Application.Main.Models.Campaigns;

public class Campaign
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    [NotMapped] public virtual List<DomainUser> Players { get; set; }

    public int OwnerId { get; set; }

    [NotMapped] 
    public virtual DomainUser Owner { get; set; }

    public int DungeonMasterId { get; set; }

    [NotMapped] 
    public virtual DomainUser DungeonMaster { get; set; }

    [NotMapped] 
    public virtual List<UserCharacterCampaign> UserCharacters { get; set; }

    public Campaign()
    {
    }

    public Campaign(string campaignName, List<DomainUser> players, DomainUser dungeonMaster, DomainUser owner)
    {
        Name = campaignName;
        Players = players;
        DungeonMaster = dungeonMaster;
        Owner = owner;
    }
}