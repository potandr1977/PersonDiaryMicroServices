using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PersonDiary.Infrastructure.Domain.EventBus.Events;
using PersonDiary.Lifeevent.ApiClient;
using PersonDiary.Lifeevent.Dto;
using PersonDiary.Person.Dto;

namespace PersonDiary.Lifeevent.EventBus.ConsumerWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILifeEventSubscriberFactory lifeEventSubscriberFactory;
        private readonly ILifeEventApiClient lifeEventApiClient;
        
        private readonly ILogger<Worker> logger;

        public Worker(ILogger<Worker> logger,
            ILifeEventSubscriberFactory lifeEventSubscriberFactory,
            ILifeEventApiClient lifeEventApiClient)
        {
            this.lifeEventSubscriberFactory = lifeEventSubscriberFactory;
            this.lifeEventApiClient = lifeEventApiClient;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var subscriber = lifeEventSubscriberFactory.Create<PersonCreate>();
            
            subscriber.Subscribe(lifeEventCreate =>
            {
                
                lifeEventApiClient.PersonCreatedAsync(new PersonCreateDto()
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