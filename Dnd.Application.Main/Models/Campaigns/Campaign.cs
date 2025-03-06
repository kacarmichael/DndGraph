using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Core.Main.Models.Campaigns;
using Dnd.Core.Main.Models.Users;

namespace Dnd.Application.Main.Models.Campaigns;

public class Campaign : ICampaign
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }
    public List<IDomainUser> Players { get; set; }
    public IDomainUser Owner { get; set; }
    public IDomainUser DungeonMaster { get; set; }

    public Campaign(string campaignName, List<IDomainUser> players, IDomainUser dungeonMaster, IDomainUser owner)
    {
        Name = campaignName;
        Players = players;
        DungeonMaster = dungeonMaster;
        Owner = owner;
    }
}