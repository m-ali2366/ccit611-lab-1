using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Backend.Service.Configurations
{
    public class ConfigurationHelper
    {
        public static string GetConnectionString(string name = "Default")
        {
            return GetConfigurationValue($"ConnectionStrings:{name}");
        }
        public static (string host, string username, string password) GetRabbitMQCredentials()
        {
            return (GetConfigurationValue("RabbitMQ:Host"), GetConfigurationValue("RabbitMQ:Username"), GetConfigurationValue("RabbitMQ:Password"));
        }
        public static string GetMessageBrokerRoutingKey()
        {
            return GetConfigurationValue("MessageBroker:RoutingKey");
        }
        public static string GetMessageBrokerQueue()
        {
            return GetConfigurationValue("MessageBroker:Queue");
        }
        public static bool IsMessageBrokerEnabled()
        {
            var value = GetConfigurationValue("MessageBroker:Enabled");
            bool messageBrokerEnabled = Convert.ToBoolean(String.IsNullOrEmpty(value) ? false : value);

            return messageBrokerEnabled;
        }
        private static string GetConfigurationValue(string key)
        {
            //return "Development";
            var environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrEmpty(environment))
                environment = "Production";

            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"appsettings.{environment}.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();

            return root.GetSection(key).Value;
        }
    }
}
