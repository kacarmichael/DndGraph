using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Application.Main.Models.Campaigns;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Intermediate;

namespace Dnd.Application.Main.Models.Users;

public class DomainUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int AuthUserId { get; set; }

    //[ForeignKey("AuthUserId")] [NotMapped] public virtual AuthUser AuthUser { get; set; }

    public string Username { get; set; }

    [NotMapped] public virtual List<Character> Characters { get; set; }

    [NotMapped] public virtual List<UserCharacterCampaign> CampaignsPlayed { get; set; }

    [NotMapped] public virtual List<Campaign> CampaignsOwned { get; set; }

    [NotMapped] public virtual List<Campaign> CampaignsDmed { get; set; }

    public DomainUser(string username)
    {
        Username = username;
        Characters = new List<Character>();
    }
}