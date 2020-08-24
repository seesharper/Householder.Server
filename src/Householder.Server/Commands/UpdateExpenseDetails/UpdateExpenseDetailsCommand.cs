using Householder.Server.Models;

namespace Householder.Server.Commands
{
    public class UpdateExpenseDetailsCommand : ICommand<bool>
    {
        public int ExpenseId { get; }
        public Expense Expense { get; }

        public UpdateExpenseDetailsCommand(int expenseId, Expense expense)
        {
            ExpenseId = expenseId;
            Expense = expense;
        }
    }
}