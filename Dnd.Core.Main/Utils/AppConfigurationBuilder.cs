using Microsoft.Extensions.Configuration;

namespace Dnd.Core.Main.Utils;

public static class AppConfigurationBuilder
{
    public static IConfiguration Build(IConfigurationBuilder source)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Global.json");

        switch (builder.Build()["Environment"])
        {
            case "Local":
                builder.AddJsonFile("appsettings.Local.json");
                break;
            case "Development":
                builder.AddJsonFile("appsettings.Development.json");
                break;
            case "Production":
                builder.AddJsonFile("appsettings.Production.json");
                break;
        }

        var app_url = source.Build()["profiles:https:applicationUrl"];
        return builder.AddInMemoryCollection(
            new[]
            {
                new KeyValuePair<string, string?>("BaseUrl", app_url.Split(":")[0] + ":" + app_url.Split(":")[1])
            }).Build();
    }

    public static string GetConnectionString(IConfigurationBuilder source)
    {
        var server = source.Build()["Database:Server"];
        var database = source.Build()["Database:Database"];
        var user = source.Build()["Database:User Id"];
        var password = source.Build()["Database:Password"];
        return $"Server={server};Database={database};User Id={user};Password={password}";
    }
}