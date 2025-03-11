using Dnd.Core.Logging;
using Microsoft.Extensions.Logging;

namespace Dnd.Application.Logging;

public class LoggerConfig : ILoggerConfig
{
    public string ProjectName { get; set; }
    public string Prefix { get; set; }
    public LogLevel MinLogLevel { get; set; }

    public LoggerConfig(string projectName, string? prefix, LogLevel minLogLevel)
    {
        ProjectName = projectName;
        Prefix = prefix ?? ProjectName;
        MinLogLevel = minLogLevel;
    }
}