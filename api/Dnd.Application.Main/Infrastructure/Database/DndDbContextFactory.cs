using Dnd.Core.Main.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dnd.Application.Main.Infrastructure.Database;

public class DndDbContextFactory : IDesignTimeDbContextFactory<DndDbContext>
{
    public DndDbContext CreateDbContext(string[] args)
    {
        // var configuration = new ConfigurationBuilder()
        //     .SetBasePath(Directory.GetCurrentDirectory())
        //     .AddJsonFile("appsettings.json")
        //     .Build();
        var configuration = AppConfigurationBuilder.GetBuilder();
        var optionsBuilder = new DbContextOptionsBuilder<DndDbContext>();
        //var connectionString = configuration.GetConnectionString("Postgres");
        var connectionString = AppConfigurationBuilder.GetConnectionString(
            AppConfigurationBuilder.GetEnvironmentConfigurationFromBuilder(configuration));
        optionsBuilder.UseNpgsql(connectionString);
        return new DndDbContext(optionsBuilder.Options, configuration.Build());
    }
}