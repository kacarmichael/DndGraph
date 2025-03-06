namespace Dnd.Core.Main.Models.Campaigns;

public interface ICampaignSession
{
    ICampaign Campaign { get; }
    DateTime? SessionDate { get; set; }
}