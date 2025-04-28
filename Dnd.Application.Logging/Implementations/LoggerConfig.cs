using Dnd.Application.Logging.Interfaces;
using Microsoft.Extensions.Logging;

namespace Dnd.Application.Logging.Implementations;

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