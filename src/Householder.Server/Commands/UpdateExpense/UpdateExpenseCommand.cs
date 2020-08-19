using Householder.Server.Models;

namespace Householder.Server.Commands
{
    public class UpdateExpenseCommand : ICommand<Expense>
    {
        public int ExpenseId { get; }
        public Expense Expense { get; }

        public UpdateExpenseCommand(int expenseId, Expense expense)
        {
            ExpenseId = expenseId;
            Expense = expense;
        }
    }
}