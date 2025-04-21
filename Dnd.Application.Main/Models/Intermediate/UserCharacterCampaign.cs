using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Application.Main.Models.Campaigns;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Users;

namespace Dnd.Application.Main.Models.Intermediate;

public class UserCharacterCampaign
{
    public int UserId { get; set; }
    public int CharacterId { get; set; }
    public int CampaignId { get; set; }

    [NotMapped] public virtual DomainUser _User { get; set; }

    [NotMapped] public virtual Character _Character { get; set; }

    [NotMapped] public virtual Campaign _Campaign { get; set; }
}