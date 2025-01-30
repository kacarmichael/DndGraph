using Dnd.API.Models.Campaigns.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Dnd.API.Infrastructure;

public class CampaignDbContext : DbContext
{
    public CampaignDbContext(DbContextOptions<CampaignDbContext> options)
    {
        
    }
    
    public DbSet<Campaign> Campaigns { get; set; }
}