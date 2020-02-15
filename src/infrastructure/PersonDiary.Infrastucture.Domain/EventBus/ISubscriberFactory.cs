namespace PersonDiary.Infrastructure.Domain.EventBus
{
    public interface ISubscriberFactory<out T>
    {
        ISubscriber<T> Create();
    }
}