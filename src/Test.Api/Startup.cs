using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Api.Handlers;
using Test.Common.Events;
using Test.Common.Interfaces;
using Test.Common.RabbitMQ;

namespace Test.Api
{
    public class Startup
    {
        #region Ctor

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion Ctor

        #region Properties

        public IConfiguration Configuration { get; }

        #endregion Properties

        #region Methods

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddRabbitMq(Configuration);
            services.AddSingleton<IEventHandler<Moved>, MovedHandler>();
            services.AddSingleton<IEventHandler<Turned>, TurnedHandler>();
            services.AddSingleton<IEventHandler<CommandFailed>, CommandFailedHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
        }

        #endregion Methods
    }
}