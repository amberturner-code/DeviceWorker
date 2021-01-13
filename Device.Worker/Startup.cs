using DeviceWorker.Domain;
using DeviceWorker.Logging;
using DeviceWorker.Messaging.Receiver;
using DeviceWorker.Messaging.Sender;
using DeviceWorker.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.IO;

namespace DeviceWorker
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));            
        }
                
        public void ConfigureServices(IServiceCollection services)
        {
            var serviceClientSettingsConfig = Configuration.GetSection("RabbitMq");
            var serviceClientSettings = serviceClientSettingsConfig.Get<RabbitMQConfiguration>();
            services.Configure<RabbitMQConfiguration>(serviceClientSettingsConfig); 
                
            services.AddTransient<IAssignDeviceService, AssignDeviceService>();
            services.AddSingleton<IDeviceMessageSender, DeviceMessageSender>();
            services.AddSingleton<ILoggerService, LoggerService>();

            if (serviceClientSettings.Enabled)
            {
                services.AddHostedService<DeviceMessageReceiver>();
            }
        }
                
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Device Worker Service");
                });
            });
        }
    }
}
