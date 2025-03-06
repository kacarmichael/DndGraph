using Dnd.Core.Main.Models.Campaigns;

namespace Dnd.Core.Main.Repositories;

public interface ICampaignRepository
{
    Task<ICampaign> GetCampaignByIdAsync(int campaignId);
    Task<IEnumerable<ICampaign>> GetAllCampaignsAsync();
    Task<ICampaign> CreateCampaignAsync(ICampaign campaign);
    Task<ICampaign> UpdateCampaignAsync(ICampaign campaign);
    Task<ICampaign> DeleteCampaignByIdAsync(int campaignId);
    Task<ICampaign> DeleteCampaignAsync(ICampaign campaign);
}