using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Person.EventBus
{
    public class PersonPublisherFactory : PublisherFactory
    {
        private const string Topic = "PersonDiary.Person.EventBus";
        public PersonPublisherFactory(ISettingsRepository settingsRepository) : base(settingsRepository, Topic)
        {
        }
    }
}