// using Azure.Core;
// using Backend.Service.MessageBroker.Models.Messages;
// using Backend.Service.MessageBroker.Models.Messages.Base;
// using Backend.Service.Models;
// using Mapster;
// using MediatR;
// using System.Threading.Tasks;

// namespace Backend.Service.MessageBroker.Consumers
// {
//     public class SendTaskToAnalyticsConsumer : IBaseConsumer<SendTaskToAnalyticsMessage>
//     {
//         IMediator _mediator;

//         public SendTaskToAnalyticsConsumer(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         public async Task Consume(SendTaskToAnalyticsMessage message)
//         {
//             var model = message.Adapt<Order>();
//             await _mediator.Send(new AddTaskCommand(model));
//         }
//     }
// }
