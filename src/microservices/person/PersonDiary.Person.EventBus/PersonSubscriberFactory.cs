using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Person.EventBus
{
    public class PersonSubscriberFactory : SubscriberFactory, IPersonSubscriberFactory
    {
        private const string TopicReceiver = "PersonDiary.Person.EventBus";
        private const string SubscriptionId = "PersonDiary.Person.EventBus.PersonSubscriber";
        public PersonSubscriberFactory(ISettingsRepository settingsRepository) : 
            base(settingsRepository, TopicReceiver, SubscriptionId)
        {
        }
    }
}