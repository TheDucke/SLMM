using Microsoft.AspNetCore.Hosting;
using RawRabbit;
using Test.Common.Commands;
using Test.Common.Interfaces;

namespace Test.Common.RabbitMQ
{
    public class BusBuilder : BuilderBase
    {
        #region Members

        private readonly IWebHost _webHost;

        private readonly IBusClient _bus;

        #endregion Members

        #region Ctor

        public BusBuilder(IWebHost webHost, IBusClient bus)
        {
            _webHost = webHost;
            _bus = bus;
        }

        #endregion Ctor

        #region Methods

        public override ServiceHost Build()
        {
            return new ServiceHost(_webHost);
        }

        public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
        {
            var handler = (ICommandHandler<TCommand>)_webHost.Services.GetService(typeof(ICommandHandler<TCommand>));

            _bus.WithCommandHandlerAsync(handler);

            return this;
        }

        public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
        {
            var handler = (IEventHandler<TEvent>)_webHost.Services.GetService(typeof(IEventHandler<TEvent>));

            _bus.WithEventHandlerAsync(handler);

            return this;
        }

        #endregion Methods
    }
}