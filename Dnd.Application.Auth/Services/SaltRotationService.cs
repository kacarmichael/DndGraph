using System.Collections.Concurrent;
using Dnd.Core.Auth.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Dnd.Application.Auth.Services;

public class SaltRotationService : ISaltRotationService, IHostedService, IDisposable
{
    private readonly ILogger<SaltRotationService> _logger;
    private Timer _timer;
    private readonly ConcurrentDictionary<Guid, CancellationTokenSource> _operations = new();

    public SaltRotationService(ILogger<SaltRotationService> logger)
    {
        _logger = logger;
        _timer = new Timer(RotateSalts, null, TimeSpan.Zero, TimeSpan.FromHours(1));
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    private async void RotateSalts(object state)
    {
        var operationId = Guid.NewGuid();
        var cts = new CancellationTokenSource();
        _operations.TryAdd(operationId, cts);

        try
        {
            await RotateSaltsAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Salt rotation canceled");
        }
        finally
        {
            _operations.TryRemove(operationId, out _);
        }
    }

    public async Task CancelSaltRotationAsync(Guid operationId)
    {
        if (_operations.TryGetValue(operationId, out var cts))
        {
            cts.Cancel();
        }
    }

    private async Task RotateSaltsAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(10000, cancellationToken);

        _logger.LogInformation("Rotating salts");
        _logger.LogInformation("Salt rotation complete");
    }


    public void Dispose()
    {
        _timer?.Dispose();
    }
}