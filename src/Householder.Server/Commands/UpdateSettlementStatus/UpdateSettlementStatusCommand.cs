using Householder.Server.Models;

namespace Householder.Server.Commands
{
    public class UpdateSettlementStatusCommand : ICommand<bool>
    {
        public int ID { get; }
        public SettlementStatus SettlementStatus { get; }

        public UpdateSettlementStatusCommand(int id, SettlementStatus settlementStatus)
        {
            ID = id;
            SettlementStatus = settlementStatus;
        }
    }
}