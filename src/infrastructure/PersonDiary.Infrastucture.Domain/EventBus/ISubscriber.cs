using System;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Domain.EventBus
{
    public interface ISubscriber<out T>
    {
        Task SubscribeAsync(Action<T> handler); 
    }
}