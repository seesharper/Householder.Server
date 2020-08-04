using System.Threading.Tasks;

namespace Householder.Server.Commands
{
    public interface ICommandProcessor
    {
        Task<TResult> ProcessAsync<TResult>(ICommand<TResult> command);
    }
}