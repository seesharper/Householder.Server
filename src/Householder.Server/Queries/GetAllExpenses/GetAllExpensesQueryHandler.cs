using System.Collections.Generic;
using Householder.Server.Models;

namespace Householder.Server.Queries
{
    public class GetAllExpensesQueryHandler : IQueryHandler<GetAllExpensesQuery, IEnumerable<Expense>>
    {
        public System.Threading.Tasks.Task<IEnumerable<Expense>> Handle(GetAllExpensesQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}