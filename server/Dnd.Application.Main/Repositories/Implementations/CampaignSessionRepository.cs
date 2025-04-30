using Dnd.Application.Main.Infrastructure;
using Dnd.Application.Main.Models.Campaigns;
using Dnd.Application.Main.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Main.Repositories.Implementations;

public class CampaignSessionRepository : ICampaignSessionRepository<CampaignSession>
{
    private readonly DndDbContext _context;

    public CampaignSessionRepository(DndDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CampaignSession>> GetCampaignSessionsAsync()
    {
        return await Queryable
            .OfType<CampaignSession>(_context.CampaignSessions)
            .ToListAsync();
    }

    public async Task<CampaignSession> GetCampaignSessionByIdAsync(int campaignSessionId)
    {
        return await _context.CampaignSessions.FirstOrDefaultAsync(x => x.Id == campaignSessionId);
    }

    public async Task<CampaignSession> GetCampaignSessionAsync(CampaignSession campaignSession)
    {
        return await Task.FromResult<CampaignSession>(_context.CampaignSessions.Find(campaignSession));
    }

    public async Task<CampaignSession> UpdateCampaignSessionAsync(CampaignSession campaignSession)
    {
        _context.CampaignSessions.Update(campaignSession);
        await _context.SaveChangesAsync();
        return campaignSession;
    }

    public async Task<CampaignSession> DeleteCampaignSessionByIdAsync(int campaignSessionId)
    {
        var campaignSession = await _context.CampaignSessions.FirstOrDefaultAsync(x => x.Id == campaignSessionId);
        _context.CampaignSessions.Remove(campaignSession);
        await _context.SaveChangesAsync();
        return campaignSession;
    }

    public async Task<CampaignSession> DeleteCampaignSessionAsync(CampaignSession campaignSession)
    {
        _context.CampaignSessions.Remove(campaignSession);
        await _context.SaveChangesAsync();
        return campaignSession;
    }

    public async Task<CampaignSession> AddCampaignSessionAsync(CampaignSession campaignSession)
    {
        _context.CampaignSessions.Add(campaignSession);
        await _context.SaveChangesAsync();
        return campaignSession;
    }

    public async Task<IEnumerable<CampaignSession>> GetCampaignSessionsByCampaignIdAsync(int campaignId)
    {
        return await Task.FromResult<IEnumerable<CampaignSession>>(
            _context.CampaignSessions.Where(
                x => x.Campaign.Id == campaignId));
    }

    public async Task<CampaignSession> CreateCampaignSessionAsync(CampaignSession campaignSession)
    {
        _context.CampaignSessions.Add(campaignSession);
        await _context.SaveChangesAsync();
        return campaignSession;
    }
}