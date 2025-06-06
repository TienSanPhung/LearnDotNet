
namespace MiniATM.Entities.DomainEventQueue;
using  DomainEvent;

public interface IDomainEventQueue<T> where T : DomainEvent
{
    void Enqueue(T evt);
}