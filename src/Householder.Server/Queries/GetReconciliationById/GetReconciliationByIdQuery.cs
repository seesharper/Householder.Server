using Householder.Server.Models;

namespace Householder.Server.Queries
{
    public class GetReconciliationByIdQuery : IQuery<Reconciliation>
    {
        public int ID { get; }

        public GetReconciliationByIdQuery(int id)
        {
            ID = id;
        }
    }
}