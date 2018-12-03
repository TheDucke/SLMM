using System;
using System.Threading.Tasks;
using Test.Common.Events;
using Test.Common.Interfaces;

namespace Test.Api.Handlers
{
    public class CommandFailedHandler : IEventHandler<CommandFailed>
    {
        public async Task HandleAsync(CommandFailed @event)
        {
            await Task.CompletedTask;

            Console.WriteLine($"Error in command : {@event.Message}");
        }
    }
}