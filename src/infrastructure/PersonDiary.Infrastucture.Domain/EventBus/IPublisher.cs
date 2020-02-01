using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Domain.EventBus
{
    public interface IPublisher<in T>
    {
        Task PublishEventAsync(T publishedEvent);
    }
}