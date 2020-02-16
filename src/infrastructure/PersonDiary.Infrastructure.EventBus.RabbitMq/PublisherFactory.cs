using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.Settings;

namespace PersonDiary.Infrastructure.EventBus.RabbitMq
{
    public abstract class PublisherFactory: IPublisherFactory
    {
        private readonly string eventBusConnectionString;
        private readonly string topic;
        
        protected PublisherFactory(ISettingsRepository settingsRepository,string topic)
        {
            this.eventBusConnectionString = settingsRepository.Get(SettingKeys.EventBusConnectionStringPerson);
            this.topic = topic;
        }
        
        public IPublisher<T> Create<T>() where T : class
        {
            return new Publisher<T>(eventBusConnectionString, topic);
        }

        
    }
}