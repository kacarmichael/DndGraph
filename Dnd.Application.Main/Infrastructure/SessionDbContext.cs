using Dnd.Application.Main.Models.Campaigns;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Main.Infrastructure;

public class SessionDbContext : DbContext
{
    public SessionDbContext(DbContextOptions<SessionDbContext> options) : base(options)
    {
    }

    public DbSet<CampaignSession> CampaignSessions { get; set; }
}