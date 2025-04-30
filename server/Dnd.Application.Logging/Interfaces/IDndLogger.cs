using Microsoft.Extensions.Logging;

namespace Dnd.Application.Logging.Interfaces;

public interface IDndLogger
{
    static void Log(string source, LogLevel logLevel, string message)
    {
    }

    static void SetLogLevel(LogLevel logLevel)
    {
    }
}