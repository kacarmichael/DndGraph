using Dnd.API.Models.Campaigns.Interfaces;

namespace Dnd.API.Services;

public interface ICampaignService
{
    Task<ICampaign> CreateCampaignAsync(ICampaign campaign);
    Task<ICampaignSession> CreateCampaignSessionAsync(ICampaignSession session);
    Task<ICampaign> GetCampaignByIdAsync(int id);
    Task<ICampaignSession> GetCampaignSessionByIdAsync(int id);
    Task<ICampaign> UpdateCampaignAsync(ICampaign campaign);
    Task<ICampaignSession> UpdateCampaignSessionAsync(ICampaignSession campaignSession);
    Task<ICampaign> DeleteCampaignByIdAsync(int id);
    Task<ICampaignSession> DeleteCampaignSessionByIdAsync(int id);
    Task<IEnumerable<ICampaign>> GetAllCampaignsAsync();

    Task<IEnumerable<ICampaignSession>> GetAllCampaignSessionsAsync();
    // Task<IEnumerable<ICampaignSession>> GetCampaignSessionsByCampaignIdAsync(int campaignId);
    // Task<IEnumerable<ICampaign>> GetCampaignsByUserIdAsync(int userId);
    // Task<IEnumerable<ICampaignSession>> GetCampaignSessionsByUserIdAsync(int userId);
}