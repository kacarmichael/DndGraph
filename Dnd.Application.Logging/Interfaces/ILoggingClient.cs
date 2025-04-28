namespace Dnd.Application.Logging.Interfaces;

public interface ILoggingClient
{
    ILoggerConfig Config { get; }
    //void LogMessage(string message);

    void LogInformation(string message);
}