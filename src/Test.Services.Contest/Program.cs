using Test.Common.Commands;
using Test.Common.RabbitMQ;

namespace Test.Services.SLMM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<Turn>()
                .SubscribeToCommand<Move>()
                .Build()
                .Run();
        }
    }
}