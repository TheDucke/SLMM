using System;
using System.Threading.Tasks;
using Test.Common.Events;
using Test.Common.Interfaces;

namespace Test.Api.Handlers
{
    public class MovedHandler : IEventHandler<Moved>
    {
        public async Task HandleAsync(Moved @event)
        {
            await Task.CompletedTask;

            Console.WriteLine($"New position : {nameof(@event.CurrentPosition.X)} , {nameof(@event.CurrentPosition.Y)}");
        }
    }
}