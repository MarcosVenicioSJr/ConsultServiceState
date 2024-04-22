using ConsultServiceState.Entities.Interfaces;

namespace ConsultServiceState
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConsultServiceState _consultService;
        private readonly string _url = "https://www.google.com.br/";

        public Worker(ILogger<Worker> logger, IConsultServiceState consultService)
        {
            _logger = logger;
            _consultService = consultService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);

                HttpResponseMessage responseMessage = await _consultService.GetAsync(_url);

                if(responseMessage.IsSuccessStatusCode)
                    Environment.Exit(0);
                else
                    // Envia o log pro Mongo e Rabbit
                    Environment.Exit(0);
            }
        }
    }
}
