using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.EventBus.RabbitMq;
using PersonDiary.Person.Domain.EventBus;

namespace PersonDiary.Person.EventBus
{
    public class PersonSubscriberFactory : SubscriberFactory, IPersonSubscriberFactory
    {
        protected PersonSubscriberFactory(ISettingsRepository settingsRepository, string topicReceiver, string subscriptionId) : 
            base(settingsRepository, topicReceiver, subscriptionId)
        {
        }
    }
}