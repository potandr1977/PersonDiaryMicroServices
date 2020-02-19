using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.EventBus.Events;
using PersonDiary.Infrastructure.EventBus.RabbitMq;
using PersonDiary.Person.Domain.EventBus;

namespace PersonDiary.Peron.EventBus.ConsumerWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IPersonSubscriberFactory personSubscriberFactory;
        private readonly ISubscriber<PersonCreate> subscriber;
        public Worker(ILogger<Worker> logger , IPersonSubscriberFactory personSubscriberFactory)
        {
            this.logger = logger;
            this.personSubscriberFactory = personSubscriberFactory;
            subscriber = personSubscriberFactory.Create<PersonCreate>();
            subscriber.Subscribe(personCreate =>
            {
                this.logger.LogInformation($"PersonCreate event received, id ={personCreate.Id}");   
            });
            
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}