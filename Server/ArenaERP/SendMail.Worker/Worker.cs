using SecurityBLLManager.ERP.IBranchService.Interface;

namespace SendMail.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IBranchServiceBLLManager _bLLManager;

        public Worker(ILogger<Worker> logger, IBranchServiceBLLManager bLLManager)
        {
            _logger = logger;
            _bLLManager = bLLManager;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var emails = _bLLManager.GetAllBranchByComp(1);
                
                await Task.Delay(30000, stoppingToken);
            }
        }
    }
}