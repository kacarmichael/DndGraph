using Dnd.Application.Main.Models.Campaigns;
using Dnd.Application.Main.Repositories.Interfaces;
using Dnd.Application.Main.Services.Interfaces;

namespace Dnd.Application.Main.Services.Implementations;

public class CampaignService : ICampaignService
{
    private readonly ICampaignRepository<Campaign> _campaignRepository;
    private readonly ICampaignSessionRepository<CampaignSession> _campaignSessionRepository;

    public CampaignService(ICampaignRepository<Campaign> campaignRepository,
        ICampaignSessionRepository<CampaignSession> campaignSessionRepository)
    {
        _campaignRepository = campaignRepository;
        _campaignSessionRepository = campaignSessionRepository;
    }

    public async Task<Campaign> CreateCampaignAsync(Campaign campaign)
    {
        return await _campaignRepository.CreateCampaignAsync(campaign);
    }

    public async Task<CampaignSession> CreateCampaignSessionAsync(CampaignSession campaignSession)
    {
        var csImpl = campaignSession as CampaignSession;
        if (csImpl == null)
        {
            throw new ArgumentException("Invalid CampaignSession in Creation");
        }

        return await _campaignSessionRepository.CreateCampaignSessionAsync(csImpl);
    }

    public async Task<Campaign> GetCampaignByIdAsync(int campaignId)
    {
        return await _campaignRepository.GetCampaignByIdAsync(campaignId);
    }

    public async Task<CampaignSession> GetCampaignSessionByIdAsync(int campaignSessionId)
    {
        return await _campaignSessionRepository.GetCampaignSessionByIdAsync(campaignSessionId);
    }

    public async Task<IEnumerable<CampaignSession>> GetCampaignSessionsByCampaignIdAsync(int campaignId)
    {
        return await _campaignSessionRepository.GetCampaignSessionsByCampaignIdAsync(campaignId);
    }

    public async Task<CampaignSession> UpdateCampaignSessionAsync(CampaignSession campaignSession)
    {
        var csImpl = campaignSession as CampaignSession;
        if (csImpl == null)
        {
            throw new ArgumentException("Invalid CampaignSession in Creation");
        }

        return await _campaignSessionRepository.UpdateCampaignSessionAsync(csImpl);
    }

    public async Task<Campaign> UpdateCampaignAsync(Campaign campaign)
    {
        var campImpl = campaign as Campaign;
        if (campImpl == null)
        {
            throw new ArgumentException("Invalid Campaign in Creation");
        }

        return await _campaignRepository.UpdateCampaignAsync(campImpl);
    }

    public async Task<Campaign> DeleteCampaignByIdAsync(int campaignId)
    {
        var campaign = await _campaignRepository.GetCampaignByIdAsync(campaignId);
        return await _campaignRepository.DeleteCampaignAsync(campaign);
    }

    public async Task<CampaignSession> DeleteCampaignSessionByIdAsync(int campaignSessionId)
    {
        var campaignSession = await _campaignSessionRepository.GetCampaignSessionByIdAsync(campaignSessionId);
        return await _campaignSessionRepository.DeleteCampaignSessionAsync(campaignSession);
    }

    public async Task<IEnumerable<Campaign>> GetAllCampaignsAsync()
    {
        return await _campaignRepository.GetAllCampaignsAsync();
    }

    public async Task<IEnumerable<CampaignSession>> GetAllCampaignSessionsAsync()
    {
        return await _campaignSessionRepository.GetCampaignSessionsAsync();
    }
}