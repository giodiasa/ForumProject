using Forum.Core.Common.Enums;
using Forum.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Forum.Application.Jobs
{
    public class TopicActivityMonitorService : BackgroundService
    {
        private readonly ILogger<TopicActivityMonitorService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public TopicActivityMonitorService(ILogger<TopicActivityMonitorService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var topicRepository = scope.ServiceProvider.GetRequiredService<ITopicRepository>();
                    try
                    {
                        var topics = await topicRepository.GetAllTopicsAsync(x => x.Status == Status.Active);
                        foreach (var topic in topics)
                        {
                            var difference = DateTime.Now - topic.LastCommentDate;
                            if (difference.TotalDays >= 30)
                            {
                                topic.Status = Status.Inactive;
                                _logger.LogInformation($"Topic - {topic.Title} is now inactive");
                            }
                        }
                        await topicRepository.Save();
                    }
                    catch (Exception ex)
                    {

                        _logger.LogError(ex.Message);
                    }
                }

                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
    }
}
