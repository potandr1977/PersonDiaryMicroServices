using System;
using System.Threading.Tasks;
using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.EventBus.Events;
using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Test.RabbitMq.Emitter
{
    class Program
    {
        private const string RabbitConnectionString = "host=localhost";
        private const string Topic = "Z.A";

        private static void Main(string[] args)
        {
            var input = "";
            while ((input = Console.ReadLine()) != "Quit")
            {
                IPublisher<PersonCreate> publisher = new Publisher<PersonCreate>(RabbitConnectionString, Topic);
                publisher.PublishEvent(new PersonCreate { Id = int.Parse(input) });
            }
            Console.WriteLine("Published");
            Console.ReadLine();
        }
    }
}