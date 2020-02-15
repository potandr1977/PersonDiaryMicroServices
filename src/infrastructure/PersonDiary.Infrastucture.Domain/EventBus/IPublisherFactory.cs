namespace PersonDiary.Infrastructure.Domain.EventBus
{
    public interface IPublisherFactory<in T>
    {
        IPublisher<T> Create();
    }
}