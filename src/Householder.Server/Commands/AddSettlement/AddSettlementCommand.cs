using Householder.Server.Models;

namespace Householder.Server.Commands
{
    public class AddSettlementCommand : ICommand<long>
    {
        public int ReconciliationId { get; }
        public Settlement Settlement { get; }

        public AddSettlementCommand(int reconciliationId, Settlement settlement)
        {
            ReconciliationId = reconciliationId;
            Settlement = settlement;
        }
    }
}