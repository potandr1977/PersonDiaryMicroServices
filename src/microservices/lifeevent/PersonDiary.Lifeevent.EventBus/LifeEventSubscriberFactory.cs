using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.EventBus.RabbitMq;
using PersonDiary.Lifeevent.Domain.EventBus;

namespace PersonDiary.Lifeevent.EventBus
{
    public class LifeEventSubscriberFactory : SubscriberFactory, ILifeEventSubscriberFactory
    {
        private const string TopicReceiver = "PersonDiary.LifeEvent.EventBus";
        private const string SubscriptionId = "PersonDiary.LifeEvent.EventBus.LifeEventSubscriber";
        public LifeEventSubscriberFactory(ISettingsRepository settingsRepository) : 
            base(settingsRepository, TopicReceiver, SubscriptionId)
        {
        }
    }
}