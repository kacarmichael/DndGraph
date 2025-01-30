using System.ComponentModel.DataAnnotations.Schema;
using Dnd.API.Models.Campaigns.Interfaces;
using Dnd.API.Models.Users.Interfaces;

namespace Dnd.API.Models.Campaigns.Implementations;

public class Campaign : ICampaign
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    public List<IUser> Players { get; set; }
    public IUser Owner { get; set; }
    public IUser DungeonMaster { get; set; }

    public Campaign(string campaignName, List<IUser> players, IUser dungeonMaster, IUser owner)
    {
        Name = campaignName;
        Players = players;
        DungeonMaster = dungeonMaster;
        Owner = owner;
    }
}