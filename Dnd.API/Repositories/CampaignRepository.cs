using Dnd.API.Infrastructure;
using Dnd.API.Models.Campaigns.Implementations;
using Dnd.API.Models.Campaigns.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.API.Repositories;

public class CampaignRepository<TCampaign> : ICampaignRepository where TCampaign : class, ICampaign
{
    private readonly CampaignDbContext _context;

    public CampaignRepository(CampaignDbContext context)
    {
        _context = context;
    }

    public async Task<ICampaign> GetCampaignByIdAsync(int campaignId)
    {
        return await _context.Campaigns.FindAsync(campaignId);
    }

    public async Task<ICampaign> AddCampaignAsync(ICampaign campaign)
    {
        _context.Campaigns.Add((Campaign)campaign);
        await _context.SaveChangesAsync();
        return campaign;
    }

    public async Task<IEnumerable<ICampaign>> GetCampaignsAsync()
    {
        return await _context.Campaigns
            .OfType<ICampaign>()
            .ToListAsync();
    }

    public async Task<ICampaign> UpdateCampaignAsync(ICampaign campaign)
    {
        _context.Campaigns.Update((Campaign)campaign);
        await _context.SaveChangesAsync();
        return campaign;
    }

    public async Task<ICampaign> DeleteCampaignAsync(ICampaign campaign)
    {
        _context.Campaigns.Remove((Campaign)campaign);
        await _context.SaveChangesAsync();
        return campaign;
    }

    public async Task<ICampaign> DeleteCampaignByIdAsync(int campaignId)
    {
        var campaign = await _context.Campaigns.FindAsync(campaignId);
        _context.Campaigns.Remove(campaign);
        await _context.SaveChangesAsync();
        return campaign;
    }
}