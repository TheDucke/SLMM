using System.Threading.Tasks;

namespace Test.Common.Interfaces
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event);
    }
}