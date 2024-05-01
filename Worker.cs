using ConsultServiceState.Entities;
using ConsultServiceState.Entities.Enum;
using ConsultServiceState.Entities.Interfaces;

namespace ConsultServiceState
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConsultServiceState _consultService;
        private readonly IRabbitMQ _rabbitMQ;
        private readonly string _url = "https://www.google.com.br/";

        public Worker(ILogger<Worker> logger, IConsultServiceState consultService, IRabbitMQ rabbitMQ)
        {
            _logger = logger;
            _consultService = consultService;
            _rabbitMQ = rabbitMQ;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            MessageRabbit messageRabbit = new();

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, stoppingToken);

                try
                {
                    HttpResponseMessage responseMessage = await _consultService.GetAsync(_url);

                    if (responseMessage != null)
                    {
                        messageRabbit.Message = responseMessage.Content + $"Request send at {DateTime.UtcNow}";
                        messageRabbit.Queue = RabbitQueueEnum.Success.ToString();
                        _rabbitMQ.CreateLog(messageRabbit);
                    }
                }
                catch (Exception ex)
                {
                    messageRabbit.Message = ex.Message + $" Error captured at {DateTime.UtcNow}";
                    messageRabbit.Queue = RabbitQueueEnum.Error.ToString();
                    _rabbitMQ.CreateLog(messageRabbit);
                }
            }
        }
    }
}
