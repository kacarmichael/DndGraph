using Microsoft.Extensions.Logging;

namespace Dnd.Core.Logging;

public interface ILoggerConfig
{
    string ProjectName { get; set; }
    string Prefix { get; set; }
    LogLevel MinLogLevel { get; set; }
}