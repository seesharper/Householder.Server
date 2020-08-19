using Householder.Server.Models;
using System.Collections.Generic;

namespace Householder.Server.Queries
{
    public class GetAllExpensesQuery : IQuery<IEnumerable<Expense>>
    {
        public int Limit { get; }

        public GetAllExpensesQuery(int limit)
        {
            Limit = limit;
        }
    }
}