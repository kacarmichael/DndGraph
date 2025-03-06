using Dnd.Application.Main.Infrastructure;
using Dnd.Application.Main.Models.Campaigns;
using Dnd.Core.Main.Models.Campaigns;
using Dnd.Core.Main.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Main.Repositories;

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

    public async Task<ICampaign> CreateCampaignAsync(ICampaign campaign)
    {
        _context.Campaigns.Add((Campaign)campaign);
        await _context.SaveChangesAsync();
        return campaign;
    }

    public async Task<IEnumerable<ICampaign>> GetAllCampaignsAsync()
    {
        return await Queryable
            .OfType<ICampaign>(_context.Campaigns)
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