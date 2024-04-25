using Backend.Service.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Service.Configurations.CAP
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCapService(this IServiceCollection services)
        {
            var rabbitMQ = ConfigurationHelper.GetRabbitMQCredentials();

            services.AddCap(x =>
            {
                x.UseSqlServer(ConfigurationHelper.GetConnectionString());
                x.UseEntityFramework<EntitiesContext>();
                x.UseRabbitMQ(opt =>
                {
                    opt.HostName = rabbitMQ.host;
                    opt.Port = 5672;
                    opt.UserName = rabbitMQ.username;
                    opt.Password = rabbitMQ.password;
                    opt.ExchangeName = "cap.default.router";

                });
                x.UseDashboard();
            });
            return services;
        }
    }
}
