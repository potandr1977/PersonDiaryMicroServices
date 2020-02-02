using System;
using EasyNetQ;
using PersonDiary.Infrastructure.Domain.EventBus;

namespace PersonDiary.Infrastructure.EventBus.RabbitMq
{
    public abstract class Subscriber<T> : ISubscriber<T> where T : class
    {
        private readonly string rabbitConnectionString;
        private readonly string topic;
        private readonly string subscriptionId;

        protected Subscriber(string rabbitConnectionString, string topic, string subscriptionId)
        {
            this.rabbitConnectionString = rabbitConnectionString;
            this.topic = topic;
            this.subscriptionId = subscriptionId;
        }

        public void Subscribe(Action<T> handler)
        {
            using var bus = RabbitHutch.CreateBus(rabbitConnectionString);
            bus.Subscribe<T>(subscriptionId, handler, x => x.WithTopic(topic));
        }
    }
}