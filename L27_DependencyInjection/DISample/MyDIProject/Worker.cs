namespace MyDIProject;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    readonly IMessageWriter _messageWriter;

    public Worker(ILogger<Worker> logger, IMessageWriter messageWriter)
    {
        _logger = logger;
        this. _messageWriter = messageWriter;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _messageWriter.WriteMessage("Thông báo đến từ: ");
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}