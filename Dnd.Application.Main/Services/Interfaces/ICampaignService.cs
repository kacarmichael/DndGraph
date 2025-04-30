using Dnd.Application.Main.Models.Campaigns;

namespace Dnd.Application.Main.Services.Interfaces;

public interface ICampaignService
{
    Task<Campaign> CreateCampaignAsync(Campaign campaign);
    Task<CampaignSession> CreateCampaignSessionAsync(CampaignSession session);
    Task<Campaign> GetCampaignByIdAsync(int id);
    Task<CampaignSession> GetCampaignSessionByIdAsync(int id);
    Task<Campaign> UpdateCampaignAsync(Campaign campaign);
    Task<CampaignSession> UpdateCampaignSessionAsync(CampaignSession campaignSession);
    Task<Campaign> DeleteCampaignByIdAsync(int id);
    Task<CampaignSession> DeleteCampaignSessionByIdAsync(int id);
    Task<IEnumerable<Campaign>> GetAllCampaignsAsync();

    Task<IEnumerable<CampaignSession>> GetAllCampaignSessionsAsync();
    // Task<IEnumerable<ICampaignSession>> GetCampaignSessionsByCampaignIdAsync(int campaignId);
    // Task<IEnumerable<ICampaign>> GetCampaignsByUserIdAsync(int userId);
    // Task<IEnumerable<ICampaignSession>> GetCampaignSessionsByUserIdAsync(int userId);
}