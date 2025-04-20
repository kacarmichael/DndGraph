namespace Dnd.Core.Main.Repositories;

public interface ICampaignSessionRepository<T>
{
    Task<T> GetCampaignSessionByIdAsync(int campaignId);
    Task<IEnumerable<T>> GetCampaignSessionsAsync();
    Task<IEnumerable<T>> GetCampaignSessionsByCampaignIdAsync(int campaignId);
    Task<T> CreateCampaignSessionAsync(T campaignSession);
    Task<T> UpdateCampaignSessionAsync(T campaignSession);
    Task<T> DeleteCampaignSessionByIdAsync(int campaignSessionId);
    Task<T> DeleteCampaignSessionAsync(T campaignSession);
}