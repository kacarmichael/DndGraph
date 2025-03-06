using Dnd.Core.Main.Models.Campaigns;

namespace Dnd.Core.Main.Repositories;

public interface ICampaignSessionRepository
{
    Task<ICampaignSession> GetCampaignSessionByIdAsync(int campaignId);
    Task<IEnumerable<ICampaignSession>> GetCampaignSessionsAsync();
    Task<IEnumerable<ICampaignSession>> GetCampaignSessionsByCampaignIdAsync(int campaignId);
    Task<ICampaignSession> CreateCampaignSessionAsync(ICampaignSession campaignSession);
    Task<ICampaignSession> UpdateCampaignSessionAsync(ICampaignSession campaignSession);
    Task<ICampaignSession> DeleteCampaignSessionByIdAsync(int campaignSessionId);
    Task<ICampaignSession> DeleteCampaignSessionAsync(ICampaignSession campaignSession);
}