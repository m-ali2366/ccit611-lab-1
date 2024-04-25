using Backend.Service.MessageBroker.Models.Messages.Base;

namespace Backend.Service.MessageBroker.Models.Events
{
    public class MessageBrokerEvent
    {
        public MessageBrokerEvent(BaseMessage message, params string[] targets)
        {
            Message = message;
            Targets = targets;
        }

        public BaseMessage Message { get; init; }
        public string[] Targets { get; init; }

    }
}
