using System;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Domain.EventBus
{
    public interface ISubscriber<out T>
    {
        Task Subscribe<T>(Action<T> handler);
    }
}