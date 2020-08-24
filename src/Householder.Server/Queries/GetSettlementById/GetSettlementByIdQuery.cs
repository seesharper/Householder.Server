using Householder.Server.Models;

namespace Householder.Server.Queries
{
    public class GetSettlementByIdQuery : IQuery<Settlement>
    {
        public int SettlementId { get; }

        public GetSettlementByIdQuery(int settlementId)
        {
            SettlementId = settlementId;
        }
    }
}