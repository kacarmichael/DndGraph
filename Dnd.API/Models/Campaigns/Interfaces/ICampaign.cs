using Dnd.API.Models.Users.Interfaces;

namespace Dnd.API.Models.Campaigns.Interfaces;

public interface ICampaign
{
    int Id { get; }
    string Name { get; }
    List<IUser> Players { get; set; }
    IUser Owner { get; }
    IUser DungeonMaster { get; set; }
}