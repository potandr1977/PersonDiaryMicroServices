using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Domain.EventBus
{
    public interface IPublisher<T>
    {
        Task PublishEventAsync(T publishedEvent);
    }
}