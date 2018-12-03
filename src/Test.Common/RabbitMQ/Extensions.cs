using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using System.Reflection;
using System.Threading.Tasks;
using Test.Common.Commands;
using Test.Common.Interfaces;

namespace Test.Common.RabbitMQ
{
    public static class Extensions
    {
        #region Extension Methods

        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg), ctx => ctx.UseSubscribeConfiguration(cfg => cfg.FromDeclaredQueue(queue => queue.WithName(GetQueueName<TCommand>()))));

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus, IEventHandler<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg), ctx => ctx.UseSubscribeConfiguration(cfg => cfg.FromDeclaredQueue(queue => queue.WithName(GetQueueName<TEvent>()))));

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RabbitMQOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);

            var client =  RawRabbitFactory.CreateSingleton(new RawRabbitOptions() { ClientConfiguration = options });

            services.AddSingleton<IBusClient>(_ => client);
        }

        #endregion Extension Methods

        #region Methods

        private static string GetQueueName<T>() => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";

        #endregion Methods
    }
}