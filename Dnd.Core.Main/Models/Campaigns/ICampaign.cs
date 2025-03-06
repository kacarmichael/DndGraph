using Dnd.Core.Main.Models.Users;

namespace Dnd.Core.Main.Models.Campaigns;

public interface ICampaign
{
    int Id { get; }
    string Name { get; }
    List<IDomainUser> Players { get; set; }
    IDomainUser Owner { get; }
    IDomainUser DungeonMaster { get; set; }
}