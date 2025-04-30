using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Dnd.Application.Main.Infrastructure.Database;

public class DndDbContextFactory : IDesignTimeDbContextFactory<DndDbContext>
{
    public DndDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var optionsBuilder = new DbContextOptionsBuilder<DndDbContext>();
        var connectionString = configuration.GetConnectionString("Postgres");
        optionsBuilder.UseNpgsql(connectionString);
        return new DndDbContext(optionsBuilder.Options, configuration);
    }
}