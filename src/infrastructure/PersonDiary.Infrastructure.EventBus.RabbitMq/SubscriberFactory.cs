using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.Settings;

namespace PersonDiary.Infrastructure.EventBus.RabbitMq
{
    public class SubscriberFactory : ISubscriberFactory
    {
        private readonly string eventBusConnectionString;
        private readonly string topicReceiver;
        private readonly string subscriptionId;

        protected SubscriberFactory(ISettingsRepository settingsRepository,string topicReceiver,string subscriptionId)
        {
            this.eventBusConnectionString = settingsRepository.Get(SettingKeys.EventBusConnectionStringPerson);
            this.topicReceiver = topicReceiver;
            this.subscriptionId = subscriptionId;
        }
        
        public ISubscriber<T> Create<T>() where T : class
        {
            return new Subscriber<T>(eventBusConnectionString, topicReceiver, subscriptionId);
        }
    }
}