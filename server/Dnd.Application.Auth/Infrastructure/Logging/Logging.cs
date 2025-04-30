using Microsoft.Extensions.Logging;

namespace Dnd.Application.Auth.Infrastructure.Logging;

public class AuthLoggerProvider : ILoggerProvider
{
    private readonly string _prefix;
    private readonly ILoggerProvider _loggerProvider;

    public AuthLoggerProvider(string prefix, ILoggerProvider loggerProvider)
    {
        _prefix = prefix;
        _loggerProvider = loggerProvider;
    }

    public ILogger CreateLogger(string categoryName) =>
        new AuthLogger(_prefix, _loggerProvider.CreateLogger(categoryName));

    public void Dispose() => _loggerProvider.Dispose();
}

public class AuthLogger : ILogger
{
    private readonly string _prefix;
    private readonly ILogger _logger;

    public AuthLogger(string prefix, ILogger logger)
    {
        _prefix = prefix;
        _logger = logger;
    }

    public IDisposable BeginScope<TState>(TState state) => _logger.BeginScope(state);

    public bool IsEnabled(LogLevel logLevel) => _logger.IsEnabled(logLevel);

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
        Func<TState, Exception, string> formatter)
    {
        _logger.Log(logLevel, eventId, state, exception, formatter);
    }
}