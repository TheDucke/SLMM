using Microsoft.AspNetCore.Hosting;
using RawRabbit;

namespace Test.Common.RabbitMQ
{
    public class HostBuilder : BuilderBase
    {
        #region Members

        private readonly IWebHost _webHost;

        private IBusClient _bus;

        #endregion Members

        #region Ctor

        public HostBuilder(IWebHost webHost)
        {
            _webHost = webHost;
        }

        #endregion Ctor

        #region Methods

        public BusBuilder UseRabbitMq()
        {
            _bus = (IBusClient)_webHost.Services.GetService(typeof(IBusClient));

            return new BusBuilder(_webHost, _bus);
        }

        public override ServiceHost Build()
        {
            return new ServiceHost(_webHost);
        }

        #endregion Methods
    }
}