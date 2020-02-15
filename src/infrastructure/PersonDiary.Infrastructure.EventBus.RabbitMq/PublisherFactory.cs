using PersonDiary.Infrastructure.Domain.EventBus;

namespace PersonDiary.Infrastructure.EventBus.RabbitMq
{
    public class PublisherFactory<T> : IPublisherFactory<T> where T : class
    {
        private readonly string rabbitConnectionString;
        private readonly string topic;

        public PublisherFactory(string rabbitConnectionString)
        {
            this.rabbitConnectionString = rabbitConnectionString;
            this.topic = topic;
        }
        
        public IPublisher<T> Create()
        {
            return new Publisher<T>(rabbitConnectionString, topic);
        }

        
    }
}