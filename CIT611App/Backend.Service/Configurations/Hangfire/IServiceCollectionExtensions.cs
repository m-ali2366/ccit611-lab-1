using Hangfire;
using Hangfire.Redis.StackExchange;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;

namespace Backend.Service.Configurations.Hangfire
{
    public static class IServiceCollectionExtensions
    {
        public static void AddHangfire(this IServiceCollection services, IConfiguration configuration)
        {
            bool isEnabled = configuration.GetValue<bool>("Hangfire:Enabled");
            if (!isEnabled)
                return;

            var redis = ConnectionMultiplexer.Connect(configuration.GetValue<string>("Hangfire:Redis"));
            services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseRedisStorage(redis, new RedisStorageOptions
                {
                    Prefix = configuration.GetValue<string>("Hangfire:ChannelPrefix"),
                    FetchTimeout = TimeSpan.FromMinutes(5)
                }));
            services.AddHangfireServer();
        }
    }
}
