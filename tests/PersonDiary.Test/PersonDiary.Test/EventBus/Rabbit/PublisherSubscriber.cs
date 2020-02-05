using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.Consul;
using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.EventBus.Events;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Test.EventBus.Rabbit
{
    [TestFixture]
    public class Publisher
    {
        private IPublisher<PersonCreate> publisher;
        private ISubscriber<PersonCreate> subscriber;
        private const string RabbitConnectionString = "host=localhost";
        private const string Topic = "X.A";
        private const string TopicReceiver = "X.*";
        private const string SubscriptionId = "MySubscription";

        [SetUp]
        public void SetUp()
        {
            publisher = new Publisher<PersonCreate>(RabbitConnectionString, Topic);
            subscriber = new Subscriber<PersonCreate>(RabbitConnectionString, TopicReceiver, SubscriptionId);
            
        }

        private static void PersonCreateHandler(PersonCreate personCreate)
        {
            var person = personCreate;
        }

        [Test] [Order(0)]
        public async Task Publish()
        {
            await publisher.PublishEventAsync(new PersonCreate{ Id = 379});
        }
        
        [Test] [Order(1)]
        public void Subscribe()
        {
            subscriber.Subscribe(PersonCreateHandler);
        }
    }

   
}