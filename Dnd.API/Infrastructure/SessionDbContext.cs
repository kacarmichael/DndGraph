using Dnd.API.Models.Campaigns.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Dnd.API.Infrastructure;

public class SessionDbContext : DbContext
{
    public SessionDbContext(DbContextOptions<SessionDbContext> options)
    {
        
    }
    
    public DbSet<CampaignSession> CampaignSessions { get; set; }
}