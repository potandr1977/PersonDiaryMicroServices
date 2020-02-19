using System;
using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.EventBus.Events;
using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Test.RabbitMq.Receiver
{
    class Program
    {
        private const string RabbitConnectionString = "host=localhost";
        private const string TopicReceiver = "PersonDiary.Person.EventBus";
        private const string SubscriptionId = "MySubscription";

        private static void Main(string[] args)
        {
            ISubscriber<PersonCreate> subscriber = new Subscriber<PersonCreate>(RabbitConnectionString, TopicReceiver, SubscriptionId);
            subscriber.Subscribe(PersonCreateHandler);
            Console.WriteLine("Listening for messages. Hit <return> to quit.");
            Console.ReadLine();
        }
        private static void PersonCreateHandler(PersonCreate personCreate)
        {
            Console.WriteLine($"-------   -----  {personCreate.Id}");
        }
    }
}