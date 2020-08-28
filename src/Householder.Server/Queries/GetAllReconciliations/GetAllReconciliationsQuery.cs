using System.Collections.Generic;
using Householder.Server.Models;

namespace Householder.Server.Queries
{
    public class GetAllReconciliationsQuery : IQuery<IEnumerable<Reconciliation>>
    {
        public int Limit { get; }

        public GetAllReconciliationsQuery(int limit)
        {
            Limit = limit;
        }
    }
}