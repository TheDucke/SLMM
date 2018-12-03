using Test.Common.Events;
using Test.Common.RabbitMQ;

namespace Test.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<Turned>()
                .SubscribeToEvent<Moved>()
                .SubscribeToEvent<CommandFailed>()
                .Build()
                .Run();
        }
    }
}