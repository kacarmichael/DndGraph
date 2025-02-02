using Dnd.API.Models.Campaigns.Interfaces;
using Dnd.API.Repositories;

namespace Dnd.API.Services;

public class CampaignService : ICampaignService
{
    private readonly ICampaignRepository _campaignRepository;
    private readonly ICampaignSessionRepository _campaignSessionRepository;

    public CampaignService(ICampaignRepository campaignRepository, ICampaignSessionRepository campaignSessionRepository)
    {
        _campaignRepository = campaignRepository;
        _campaignSessionRepository = campaignSessionRepository;
    }

    public async Task<ICampaign> CreateCampaignAsync(ICampaign campaign)
    {
        return await _campaignRepository.CreateCampaignAsync(campaign);
    }

    public async Task<ICampaignSession> CreateCampaignSessionAsync(ICampaignSession campaignSession)
    {
        return await _campaignSessionRepository.CreateCampaignSessionAsync(campaignSession);
    }

    public async Task<ICampaign> GetCampaignByIdAsync(int campaignId)
    {
        return await _campaignRepository.GetCampaignByIdAsync(campaignId);
    }

    public async Task<ICampaignSession> GetCampaignSessionByIdAsync(int campaignSessionId)
    {
        return await _campaignSessionRepository.GetCampaignSessionByIdAsync(campaignSessionId);
    }

    public async Task<IEnumerable<ICampaignSession>> GetCampaignSessionsByCampaignIdAsync(int campaignId)
    {
        return await _campaignSessionRepository.GetCampaignSessionsByCampaignIdAsync(campaignId);
    }

    public async Task<ICampaignSession> UpdateCampaignSessionAsync(ICampaignSession campaignSession)
    {
        return await _campaignSessionRepository.UpdateCampaignSessionAsync(campaignSession);
    }

    public async Task<ICampaign> UpdateCampaignAsync(ICampaign campaign)
    {
        return await _campaignRepository.UpdateCampaignAsync(campaign);
    }

    public async Task<ICampaign> DeleteCampaignByIdAsync(int campaignId)
    {
        var campaign = await _campaignRepository.GetCampaignByIdAsync(campaignId);
        return await _campaignRepository.DeleteCampaignAsync(campaign);
    }

    public async Task<ICampaignSession> DeleteCampaignSessionByIdAsync(int campaignSessionId)
    {
        var campaignSession = await _campaignSessionRepository.GetCampaignSessionByIdAsync(campaignSessionId);
        return await _campaignSessionRepository.DeleteCampaignSessionAsync(campaignSession);
    }

    public async Task<IEnumerable<ICampaign>> GetAllCampaignsAsync()
    {
        return await _campaignRepository.GetAllCampaignsAsync();
    }

    public async Task<IEnumerable<ICampaignSession>> GetAllCampaignSessionsAsync()
    {
        return await _campaignSessionRepository.GetAllCampaignSessionsAsync();
    }
}