using PersonDiary.Infrastructure.Domain.EventBus;

namespace PersonDiary.Infrastructure.EventBus.RabbitMq
{
    public class SubscriberFactory<T> : ISubscriberFactory<T> where T : class
    {
        private readonly string rabbitConnectionString;
        private readonly string topicReceiver;
        private readonly string subscriptionId;

        public SubscriberFactory(string rabbitConnectionString,string topicReceiver,string subscriptionId)
        {
            this.rabbitConnectionString = rabbitConnectionString;
            this.topicReceiver = topicReceiver;
            this.subscriptionId = subscriptionId;
        }
        
        public ISubscriber<T> Create()
        {
            return new Subscriber<T>(rabbitConnectionString, topicReceiver, subscriptionId);
        }
    }
}