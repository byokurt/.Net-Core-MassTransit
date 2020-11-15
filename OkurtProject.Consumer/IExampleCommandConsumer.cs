using System;
using System.Threading.Tasks;
using MassTransit;
using OkurtProject.Contract;

namespace OkurtProject.Consumer
{
    public class IExampleCommandConsumer : IConsumer<IExampleCommand>
    {
        public Task Consume(ConsumeContext<IExampleCommand> context)
        {
            var message = context.Message;
            return Task.CompletedTask;
        }
    }
}