using System.ComponentModel.DataAnnotations.Schema;
using Dnd.API.Models.Campaigns.Interfaces;

namespace Dnd.API.Models.Campaigns.Implementations;

public class CampaignSession : ICampaignSession
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public ICampaign Campaign { get; }
    public DateTime SessionDate { get; }

    public CampaignSession(ICampaign campaign, DateTime sessionDate)
    {
        Campaign = campaign;
        SessionDate = sessionDate;
    }
}