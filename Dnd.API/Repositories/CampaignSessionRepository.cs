using Dnd.API.Infrastructure;
using Dnd.API.Models.Campaigns.Implementations;
using Dnd.API.Models.Campaigns.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.API.Repositories;

public class CampaignSessionRepository : ICampaignSessionRepository
{
    private readonly SessionDbContext _context;

    public CampaignSessionRepository(SessionDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ICampaignSession>> GetCampaignSessionsAsync()
    {
        return await _context.CampaignSessions
            .OfType<ICampaignSession>()
            .ToListAsync();
    }

    public async Task<ICampaignSession> GetCampaignSessionByIdAsync(int campaignSessionId)
    {
        return await _context.CampaignSessions.FirstOrDefaultAsync(x => x.Id == campaignSessionId);
    }

    public async Task<ICampaignSession> GetCampaignSessionAsync(ICampaignSession campaignSession)
    {
        return await Task.FromResult<ICampaignSession>(_context.CampaignSessions.Find(campaignSession));
    }

    public async Task<ICampaignSession> UpdateCampaignSessionAsync(ICampaignSession campaignSession)
    {
        _context.CampaignSessions.Update((CampaignSession)campaignSession);
        await _context.SaveChangesAsync();
        return campaignSession;
    }

    public async Task<ICampaignSession> DeleteCampaignSessionByIdAsync(int campaignSessionId)
    {
        var campaignSession = await _context.CampaignSessions.FirstOrDefaultAsync(x => x.Id == campaignSessionId);
        _context.CampaignSessions.Remove(campaignSession);
        await _context.SaveChangesAsync();
        return campaignSession;
    }

    public async Task<ICampaignSession> DeleteCampaignSessionAsync(ICampaignSession campaignSession)
    {
        _context.CampaignSessions.Remove((CampaignSession)campaignSession);
        await _context.SaveChangesAsync();
        return campaignSession;
    }

    public async Task<ICampaignSession> AddCampaignSessionAsync(ICampaignSession campaignSession)
    {
        _context.CampaignSessions.Add((CampaignSession)campaignSession);
        await _context.SaveChangesAsync();
        return campaignSession;
    }

    public async Task<IEnumerable<ICampaignSession>> GetCampaignSessionsByCampaignIdAsync(int campaignId)
    {
        return await Task.FromResult<IEnumerable<ICampaignSession>>(
            _context.CampaignSessions.Where(
                x => x.Campaign.Id == campaignId));
        
    }
    
    
}