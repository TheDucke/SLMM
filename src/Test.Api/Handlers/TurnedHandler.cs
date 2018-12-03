using System;
using System.Threading.Tasks;
using Test.Common.Events;
using Test.Common.Interfaces;

namespace Test.Api.Handlers
{
    public class TurnedHandler : IEventHandler<Turned>
    {
        public async Task HandleAsync(Turned @event)
        {
            await Task.CompletedTask;

            Console.WriteLine($"New orientation : {nameof(@event.CurrentPosition.Orientation)}");
        }
    }
}