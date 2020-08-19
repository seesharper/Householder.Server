using Householder.Server.Models;

namespace Householder.Server.Commands
{
    public class UpdateExpenseCommandHandler : ICommandHandler<UpdateExpenseCommand, Expense>
    {
        public System.Threading.Tasks.Task<Expense> Handle(UpdateExpenseCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}