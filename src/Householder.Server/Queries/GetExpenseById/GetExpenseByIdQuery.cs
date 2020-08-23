using Householder.Server.Models;

namespace Householder.Server.Queries
{
    public class GetExpenseByIdQuery : IQuery<Expense>
    {
        public int Id { get; }

        public GetExpenseByIdQuery(int id)
        {
            Id = id;
        }
    }
}