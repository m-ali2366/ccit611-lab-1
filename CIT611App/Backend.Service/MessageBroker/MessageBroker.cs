using DotNetCore.CAP;
using Backend.Service.Configurations;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Reflection;
using System.Threading.Tasks;
using System;
using Backend.Service.MessageBroker.Attributes;
using Backend.Service.MessageBroker.Models.Messages.Base;
using Backend.Service.Data;
using Azure.Core;
using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;

namespace Backend.Service.MessageBroker
{
    public class MessageBroker : IMessageBroker, ICapSubscribe
    {
        private readonly string messagesNamespace = "Backend.Service.MessageBroker.Models.Messages";
        private readonly string consumersNamespace = "Backend.Service.MessageBroker.Consumers";

        private readonly ICapPublisher _capPublisher;
        private readonly IMediator _mediator;
        private readonly EntitiesContext _entitiesContext;
        private readonly ILogger<MessageBroker> _logger;
        public MessageBroker(
            ICapPublisher capPublisher,
            IMediator mediator,
            EntitiesContext entitiesContext,
            ILogger<MessageBroker> logger)
        {
            _capPublisher = capPublisher;
            _mediator = mediator;
            _entitiesContext = entitiesContext;
            _logger = logger;
        }

        [CapDirectSubscribe()]
        [CapFanoutSubscribe()]
        public async Task Consume(string message)
        {
            if (!ConfigurationHelper.IsMessageBrokerEnabled())
                return;


            using (var transaction = _entitiesContext.Database.BeginTransaction(_capPublisher, false))
            {
                try
                {
                    var baseMessage = GetMessage(message);

                    if (baseMessage == null)
                        return;

                    await InvokeConsumer(baseMessage);
                    await _entitiesContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex, $"Duplicate Order in Analytics Service");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    var msg = $"\nMessageBroker Error: {ex.Message}\n========================================";
                    _logger.LogError(ex, msg);
                    throw;
                }
            }
        }
        private BaseMessage GetMessage(string body)
        {
            var jsonObject = Newtonsoft.Json.Linq.JObject.Parse(body);
            var typeValue = jsonObject["MessageType"].ToString();

            Type type = Type.GetType($"{messagesNamespace}.{typeValue}");
            BaseMessage message = default;

            if (type != null)
            {
                message = JsonConvert.DeserializeObject(body, type) as BaseMessage;
                message.MessageType = message.MessageType.Replace("Message", "");
            }

            return message;
        }
        private async Task InvokeConsumer(BaseMessage baseMessage)
        {
            var consumerType = Type.GetType($"{consumersNamespace}.{baseMessage.MessageType}Consumer");

            if (consumerType == null)
                return;

            var consumer = Activator.CreateInstance(consumerType, _mediator);
            var method = consumerType.GetMethod("Consume");
            await method.InvokeAsync(consumer, new object[] { baseMessage });
        }
    }
    public static class ExtensionMethods
    {
        public static async Task InvokeAsync(this MethodInfo @this, object obj, params object[] parameters)
        {
            dynamic awaitable = @this.Invoke(obj, parameters);
            await awaitable;
            awaitable.GetAwaiter().GetResult();
        }
    }
}
