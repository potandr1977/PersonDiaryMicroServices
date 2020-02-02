using System;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Domain.EventBus
{
    public interface ISubscriber<out T>
    {
        void Subscribe(Action<T> handler); 
    }
}