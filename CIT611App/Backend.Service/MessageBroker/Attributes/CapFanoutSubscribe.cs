using DotNetCore.CAP;
using Backend.Service.Configurations;

namespace Backend.Service.MessageBroker.Attributes
{
    public class CapFanoutSubscribeAttribute : CapSubscribeAttribute
    {
        readonly static string routingKey = "Fanout";

        public CapFanoutSubscribeAttribute() : base(routingKey)
        {
            Group = ConfigurationHelper.GetMessageBrokerQueue();
        }
    }
}
