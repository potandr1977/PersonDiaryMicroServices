using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Domain.EventBus
{
    public interface IPublisher<in T>
    {
        public Task PublishEventAsync(T publishedEvent);
        public void PublishEvent(T publishedEvent);
    }
}