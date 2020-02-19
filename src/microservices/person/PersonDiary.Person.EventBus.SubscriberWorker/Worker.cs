using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.EventBus.Events;
using PersonDiary.Person.ApiClient;
using PersonDiary.Person.Domain.EventBus;
using PersonDiary.Person.Dto;

namespace PersonDiary.Person.EventBus.SubscriberWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IPersonSubscriberFactory personSubscriberFactory;
        private readonly IPersonApiClient personApiClient;
        
        public Worker(ILogger<Worker> logger , 
            IPersonSubscriberFactory personSubscriberFactory,
            IPersonApiClient personApiClient
            )
        {
            this.logger = logger;
            this.personSubscriberFactory = personSubscriberFactory;
            this.personApiClient = personApiClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var subscriber = personSubscriberFactory.Create<LifeEventCreate>();
            
            subscriber.Subscribe(lifeEventCreate =>
            {
                personApiClient.LifeEventCreatedAsync(new LifeEventCreatedDto()
                {
                    Id = lifeEventCreate.Id
                }); //call and forget
                
                this.logger.LogInformation($"LifeEventCreate event received, id = {lifeEventCreate.Id}");   
            });
            
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}