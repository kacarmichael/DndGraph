using System.ComponentModel.DataAnnotations.Schema;
using Dnd.API.Models.Campaigns.Interfaces;
using Dnd.API.Models.Users.Interfaces;

namespace Dnd.API.Models.Campaigns.Implementations;

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