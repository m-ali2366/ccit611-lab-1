using DotNetCore.CAP;
using Backend.Service.Configurations;
namespace Backend.Service.MessageBroker.Attributes
{
    public class CapDirectSubscribeAttribute : CapSubscribeAttribute
    {
        readonly static string routingKey = ConfigurationHelper.GetMessageBrokerRoutingKey();

        public CapDirectSubscribeAttribute() : base(routingKey)
        {
            Group = ConfigurationHelper.GetMessageBrokerQueue();
        }
    }
}
