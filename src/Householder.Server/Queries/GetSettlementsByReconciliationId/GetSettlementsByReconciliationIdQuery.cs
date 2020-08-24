using System.Collections.Generic;
using Householder.Server.Models;

namespace Householder.Server.Queries
{
    public class GetSettlementsByReconciliationIdQuery : IQuery<IEnumerable<Settlement>>
    {
        public int ReconciliationId { get; }

        public GetSettlementsByReconciliationIdQuery(int reconciliationId)
        {
            ReconciliationId = reconciliationId;
        }
    }
}
