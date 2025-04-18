using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Core.Main.Models.Campaigns;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Intermediate;
using Dnd.Core.Main.Models.Users;

namespace Dnd.Application.Main.Models.Intermediate;

public class UserCharacterCampaign : IUserCharacterCampaign
{
    public int UserId { get; set; }
    public int CharacterId { get; set; }
    public int CampaignId { get; set; }

    [NotMapped] public virtual IDomainUser _User { get; set; }

    [NotMapped] public virtual ICharacter _Character { get; set; }

    [NotMapped] public virtual ICampaign _Campaign { get; set; }
}