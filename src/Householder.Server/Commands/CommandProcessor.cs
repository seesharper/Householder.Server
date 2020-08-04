using System.Threading.Tasks;
using LightInject;

namespace Householder.Server.Commands
{
    public class CommandProcessor : ICommandProcessor
    {
        private IServiceContainer container;

        public CommandProcessor(IServiceContainer container)
        {
            this.container = container;
        }

        public async Task<TResult> ProcessAsync<TResult>(ICommand<TResult> command)
        {
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = container.GetInstance(handlerType);

            return await handler.Handle((dynamic)command);
        }
    }
}