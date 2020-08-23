using Householder.Server.Models;

namespace Householder.Server.Commands
{
    public class UpdateExpenseStatusCommand : ICommand<bool>
    {
        public int ID { get; }
        public ExpenseStatus ExpenseStatus { get; }

        public UpdateExpenseStatusCommand(int id, ExpenseStatus expenseStatus)
        {
            ID = id;
            ExpenseStatus = expenseStatus;
        }
    }
}