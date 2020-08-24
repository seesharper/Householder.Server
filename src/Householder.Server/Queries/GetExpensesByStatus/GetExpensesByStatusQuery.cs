using System.Collections.Generic;
using Householder.Server.Models;

namespace Householder.Server.Queries
{
    public class GetExpensesByStatusQuery : IQuery<IEnumerable<Expense>>
    {
        public ExpenseStatus ExpenseStatus { get; }

        public GetExpensesByStatusQuery(ExpenseStatus expenseStatus)
        {
            ExpenseStatus = expenseStatus;
        }
    }
}