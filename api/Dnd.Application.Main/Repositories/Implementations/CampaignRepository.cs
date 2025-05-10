using Dnd.Application.Main.Infrastructure;
using Dnd.Application.Main.Models.Campaigns;
using Dnd.Application.Main.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Main.Repositories.Implementations;

public class CampaignRepository : ICampaignRepository<Campaign>
{
    private readonly DndDbContext _context;

    public CampaignRepository(DndDbContext context)
    {
        _context = context;
    }

    public async Task<Campaign> GetCampaignByIdAsync(int campaignId)
    {
        return await _context.Campaigns.FindAsync(campaignId);
    }

    public async Task<Campaign> CreateCampaignAsync(Campaign campaign)
    {
        _context.Campaigns.Add((Campaign)campaign);
        await _context.SaveChangesAsync();
        return campaign;
    }

    public async Task<IEnumerable<Campaign>> GetAllCampaignsAsync()
    {
        return await Queryable
            .OfType<Campaign>(_context.Campaigns)
            .ToListAsync();
    }

    public async Task<Campaign> UpdateCampaignAsync(Campaign campaign)
    {
        _context.Campaigns.Update((Campaign)campaign);
        await _context.SaveChangesAsync();
        return campaign;
    }

    public async Task<Campaign> DeleteCampaignAsync(Campaign campaign)
    {
        _context.Campaigns.Remove((Campaign)campaign);
        await _context.SaveChangesAsync();
        return campaign;
    }

    public async Task<Campaign> DeleteCampaignByIdAsync(int campaignId)
    {
        var campaign = await _context.Campaigns.FindAsync(campaignId);
        _context.Campaigns.Remove(campaign);
        await _context.SaveChangesAsync();
        return campaign;
    }
}