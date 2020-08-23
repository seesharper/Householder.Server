using Householder.Server.Models;

namespace Householder.Server.Commands
{
    public class AddExpenseCommand : ICommand<Expense>
    {
        public Expense Expense { get; }

        public AddExpenseCommand(Expense expense)
        {
            Expense = expense;
        }
    }
}