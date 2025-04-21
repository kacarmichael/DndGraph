using System.ComponentModel.DataAnnotations.Schema;

namespace Dnd.Application.Main.Models.Campaigns;

public class CampaignSession
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public Campaign Campaign { get; }
    public DateTime? SessionDate { get; set; }

    public CampaignSession()
    {
    }

    public CampaignSession(Campaign campaign, DateTime? sessionDate)
    {
        Campaign = campaign;
        SessionDate = sessionDate ?? null;
    }
}