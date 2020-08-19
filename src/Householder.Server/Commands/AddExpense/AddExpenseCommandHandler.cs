using Householder.Server.Models;

namespace Householder.Server.Commands
{
    public class AddExpenseCommandHandler : ICommandHandler<AddExpenseCommand, Expense>
    {
        public System.Threading.Tasks.Task<Expense> Handle(AddExpenseCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}