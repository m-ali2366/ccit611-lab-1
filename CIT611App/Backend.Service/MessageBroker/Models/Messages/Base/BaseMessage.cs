using System;

namespace Backend.Service.MessageBroker.Models.Messages.Base
{
    public class BaseMessage
    {
        public string MessageID { get; set; } = Guid.NewGuid().ToString();
        public string MessageType { get; set; }
        public DateTime MessageCreatedDate { get; set; } = DateTime.UtcNow;
    }
}
