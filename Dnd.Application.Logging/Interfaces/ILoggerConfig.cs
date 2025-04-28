using Microsoft.Extensions.Logging;

namespace Dnd.Application.Logging.Interfaces;

public interface ILoggerConfig
{
    string ProjectName { get; set; }
    string Prefix { get; set; }
    LogLevel MinLogLevel { get; set; }
}