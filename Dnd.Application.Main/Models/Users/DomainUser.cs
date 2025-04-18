using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Application.Main.Models.Campaigns;
using Dnd.Application.Main.Models.Intermediate;
using Dnd.Core.Auth.Models;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Users;

namespace Dnd.Application.Main.Models.Users;

public class DomainUser : IDomainUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int AuthUserId { get; set; }

    [ForeignKey("AuthUserId")] [NotMapped] public virtual IAuthUser AuthUser { get; set; }

    public string Username { get; set; }

    [NotMapped] public virtual List<ICharacter> Characters { get; set; }

    [NotMapped] public virtual List<UserCharacterCampaign> CampaignsPlayed { get; set; }

    [NotMapped] public virtual List<Campaign> CampaignsOwned { get; set; }

    [NotMapped] public virtual List<Campaign> CampaignsDmed { get; set; }

    public DomainUser(string username)
    {
        Username = username;
        Characters = new List<ICharacter>();
    }
}