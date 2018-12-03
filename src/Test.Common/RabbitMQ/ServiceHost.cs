using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using Test.Common.Interfaces;

namespace Test.Common.RabbitMQ
{
    public class ServiceHost : IServiceHost
    {
        #region Members

        private readonly IWebHost _webHost;

        #endregion Members

        #region Ctor

        public ServiceHost(IWebHost webHost)
        {
            _webHost = webHost;
        }

        #endregion Ctor

        #region Methods

        public void Run() => _webHost.Run();

        #endregion Methods

        public static HostBuilder Create<TStartUp>(string[] args) where TStartUp : class
        {
            Console.Title = typeof(TStartUp).Namespace;

            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<TStartUp>();

            return new HostBuilder(webHostBuilder.Build());
        }
    }
}