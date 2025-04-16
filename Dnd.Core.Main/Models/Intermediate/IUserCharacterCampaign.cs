using Dnd.Core.Main.Models.Campaigns;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Users;

namespace Dnd.Core.Main.Models.Intermediate;

public interface IUserCharacterCampaign
{
    int UserId { get; set; }
    IDomainUser _User { get; set; }
    int CharacterId { get; set; }
    ICharacter _Character { get; set; }
    int CampaignId { get; set; }
    ICampaign _Campaign { get; set; }
}