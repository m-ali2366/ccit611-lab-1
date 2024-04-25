using System.Threading.Tasks;

namespace Backend.Service.MessageBroker.Models.Messages.Base
{
    public interface IBaseConsumer<T> where T : BaseMessage
    {
        Task Consume(T message);
    }
}
