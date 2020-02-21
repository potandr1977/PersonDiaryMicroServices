

using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Lifeevent.EventBus
{
    public class LifeEventPublisherFactory : PublisherFactory 
    {
        private const string Topic = "PersonDiary.Lifeevent.EventBus";
        public LifeEventPublisherFactory(ISettingsRepository settingsRepository) : base(settingsRepository, Topic)
        {
        }

        public IPublisher<T> Create<T>() where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}