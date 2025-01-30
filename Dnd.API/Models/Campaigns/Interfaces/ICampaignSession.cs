namespace Dnd.API.Models.Campaigns.Interfaces;

public interface ICampaignSession
{
    ICampaign Campaign { get; }
    DateTime SessionDate { get; }
}