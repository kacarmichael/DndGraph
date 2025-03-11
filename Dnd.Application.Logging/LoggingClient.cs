using Dnd.Core.Logging;
using Microsoft.Extensions.Logging;

namespace Dnd.Application.Logging;

public class LoggingClient : ILoggingClient
{
    public ILoggerConfig Config { get; }

    public LoggingClient(string projectName, LogLevel minLogLevel) =>
        (Config.ProjectName, Config.MinLogLevel) = (projectName, minLogLevel);

    public LoggingClient(ILoggerConfig config)
    {
        Config = config;
    }

    public void LogMessage(string message)
    {
        //if (Config.MinLogLevel > LogLevel.Information) return;
        Logger.LogMessage(message);
    }

    public void LogInformation(string message)
    {
        if (Config.MinLogLevel > LogLevel.Information) return;
        Logger.LogMessage(message);
    }
}