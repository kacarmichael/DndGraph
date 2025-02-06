using Dnd.API.Models.Campaigns.Interfaces;

namespace Dnd.API.Repositories.Interfaces;

public interface ICampaignRepository
{
    Task<ICampaign> GetCampaignByIdAsync(int campaignId);
    Task<IEnumerable<ICampaign>> GetAllCampaignsAsync();
    Task<ICampaign> CreateCampaignAsync(ICampaign campaign);
    Task<ICampaign> UpdateCampaignAsync(ICampaign campaign);
    Task<ICampaign> DeleteCampaignByIdAsync(int campaignId);
    Task<ICampaign> DeleteCampaignAsync(ICampaign campaign);
}