namespace MyDIProject;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    readonly IMessageWriter _messageWriter;
    readonly IServiceProvider service;
    readonly IServiceCLass serviceClass;

    public Worker(ILogger<Worker> logger, IMessageWriter messageWriter, IServiceProvider service, IServiceCLass serviceCLass)
    {
        _logger = logger;
        this. _messageWriter = messageWriter;
        this.service = service;
        this.serviceClass = serviceCLass;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var m1 = service.GetService<IServiceCLass>();
        
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