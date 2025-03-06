using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Core.Main.Models.Campaigns;

namespace Dnd.Application.Main.Models.Campaigns;

public class CampaignSession : ICampaignSession
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public ICampaign Campaign { get; }
    public DateTime? SessionDate { get; set; }

    public CampaignSession(ICampaign campaign, DateTime? sessionDate)
    {
        Campaign = campaign;
        SessionDate = sessionDate ?? null;
    }
}