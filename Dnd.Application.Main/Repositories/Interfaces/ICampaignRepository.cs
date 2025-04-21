namespace Dnd.Application.Main.Repositories.Interfaces;

public interface ICampaignRepository<T>
{
    Task<T> GetCampaignByIdAsync(int campaignId);
    Task<IEnumerable<T>> GetAllCampaignsAsync();
    Task<T> CreateCampaignAsync(T campaign);
    Task<T> UpdateCampaignAsync(T campaign);
    Task<T> DeleteCampaignByIdAsync(int campaignId);
    Task<T> DeleteCampaignAsync(T campaign);
}