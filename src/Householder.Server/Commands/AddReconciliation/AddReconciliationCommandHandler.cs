using System.Threading.Tasks;
using Householder.Server.DataAccess;
using Householder.Server.Models;
using MySqlConnector;

namespace Householder.Server.Commands
{
    public class AddReconciliationCommandHandler : ICommandHandler<AddReconciliationCommand, long>
    {
        private MySqlDatabase database;

        public AddReconciliationCommandHandler(MySqlDatabase database)
        {
            this.database = database;
        }

        public async Task<long> Handle(AddReconciliationCommand command)
        {
            var reconciliation = command.Reconciliation;

            var cmd = database.Connection.CreateCommand();

            cmd.CommandText = @"INSERT INTO `reconciliation` (`creator_id`, `creation_date`) VALUES (@creatorId, @creationDate)";

            cmd.Parameters.Add(new MySqlParameter("@creator_id", reconciliation.Creator.ID));
            cmd.Parameters.Add(new MySqlParameter("@creation_date", reconciliation.CreationDate));

            await cmd.ExecuteNonQueryAsync();

            return cmd.LastInsertedId;
        }
    }
}