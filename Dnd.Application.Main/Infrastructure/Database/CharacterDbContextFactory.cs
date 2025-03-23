using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Dnd.Application.Main.Infrastructure.Database;

public class CharacterDbContextFactory : IDesignTimeDbContextFactory<CharacterDbContext>
{
    public CharacterDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var optionsBuilder = new DbContextOptionsBuilder<CharacterDbContext>();
        var connectionString = configuration.GetConnectionString("Postgres");
        optionsBuilder.UseNpgsql(connectionString);
        return new CharacterDbContext(optionsBuilder.Options, configuration);
    }
}