using Dnd.Application.Main.Models.Campaigns;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Main.Infrastructure;

public class CampaignDbContext : DbContext
{
    public CampaignDbContext(DbContextOptions<CampaignDbContext> options) : base(options)
    {
    }

    public DbSet<Campaign> Campaigns { get; set; }
}