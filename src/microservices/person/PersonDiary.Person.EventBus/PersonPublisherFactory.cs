using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.EventBus.RabbitMq;
using PersonDiary.Person.Domain.EventBus;

namespace PersonDiary.Person.EventBus
{
    public class PersonPublisherFactory : PublisherFactory, IPersonPublisherFactory
    {
        private const string Topic = "PersonDiary.Person.EventBus";
        public PersonPublisherFactory(ISettingsRepository settingsRepository) : base(settingsRepository, Topic)
        {
        }
    }
}