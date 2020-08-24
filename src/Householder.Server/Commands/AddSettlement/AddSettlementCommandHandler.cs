using System.Threading.Tasks;
using Householder.Server.DataAccess;
using Householder.Server.Models;
using MySqlConnector;

namespace Householder.Server.Commands
{
    public class AddSettlementCommandHandler : ICommandHandler<AddSettlementCommand, long>
    {
        private MySqlDatabase database;

        public AddSettlementCommandHandler(MySqlDatabase database)
        {
            this.database = database;
        }

        public async Task<long> Handle(AddSettlementCommand command)
        {
            var reconciliationId = command.ReconciliationId;
            var settlement = command.Settlement;

            var cmd = database.Connection.CreateCommand();

            cmd.CommandText = @"INSERT INTO `settlement` (`reconciliation_id`, `creditor_id`, `debtor_id`, `amount`) VALUES (@reconciliationId, @creditorId, @debtorId, @amount)";

            cmd.Parameters.Add(new MySqlParameter("@reconciliationId", reconciliationId));
            cmd.Parameters.Add(new MySqlParameter("@creditorId", settlement.Creditor.ID));
            cmd.Parameters.Add(new MySqlParameter("@debtorId", settlement.Debtor.ID));
            cmd.Parameters.Add(new MySqlParameter("@amount", settlement.Amount));

            await cmd.ExecuteNonQueryAsync();

            return cmd.LastInsertedId;
        }
    }
}