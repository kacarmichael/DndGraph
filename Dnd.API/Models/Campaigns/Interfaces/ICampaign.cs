using Dnd.API.Models.Users.Interfaces;

namespace Dnd.API.Models.Campaigns.Interfaces;

public interface ICampaign
{
    int Id { get; }
    string Name { get; }
    List<IDomainUser> Players { get; set; }
    IDomainUser Owner { get; }
    IDomainUser DungeonMaster { get; set; }
}