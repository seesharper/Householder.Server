using Householder.Server.DataAccess;
using Householder.Server.Models;

namespace Householder.Server.Commands
{
    public class AddExpenseCommandHandler : ICommandHandler<AddExpenseCommand, Expense>
    {
        private MySqlDatabase database;

        public AddExpenseCommandHandler(MySqlDatabase database)
        {
            this.database = database;
        }

        public System.Threading.Tasks.Task<Expense> Handle(AddExpenseCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}