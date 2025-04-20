using Dnd.Application.Main.Models.Campaigns;
using Dnd.Core.Main.Models.Campaigns;
using Dnd.Core.Main.Repositories;
using Dnd.Core.Main.Services;

namespace Dnd.Application.Main.Services;

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

    public async Task<ICampaign> CreateCampaignAsync(ICampaign campaign)
    {
        var campImpl = campaign as Campaign;
        if (campImpl == null)
        {
            throw new ArgumentException("Invalid Campaign in Campaign Creation");
        }

        return await _campaignRepository.CreateCampaignAsync(campImpl);
    }

    public async Task<ICampaignSession> CreateCampaignSessionAsync(ICampaignSession campaignSession)
    {
        var csImpl = campaignSession as CampaignSession;
        if (csImpl == null)
        {
            throw new ArgumentException("Invalid CampaignSession in Creation");
        }

        return await _campaignSessionRepository.CreateCampaignSessionAsync(csImpl);
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
        var csImpl = campaignSession as CampaignSession;
        if (csImpl == null)
        {
            throw new ArgumentException("Invalid CampaignSession in Creation");
        }

        return await _campaignSessionRepository.UpdateCampaignSessionAsync(csImpl);
    }

    public async Task<ICampaign> UpdateCampaignAsync(ICampaign campaign)
    {
        var campImpl = campaign as Campaign;
        if (campImpl == null)
        {
            throw new ArgumentException("Invalid Campaign in Creation");
        }

        return await _campaignRepository.UpdateCampaignAsync(campImpl);
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
        return await _campaignSessionRepository.GetCampaignSessionsAsync();
    }
}