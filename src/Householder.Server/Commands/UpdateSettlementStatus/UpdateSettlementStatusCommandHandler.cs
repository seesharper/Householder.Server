using System.Collections.Generic;
using System.Threading.Tasks;
using Householder.Server.DataAccess;
using Householder.Server.Models;
using MySqlConnector;

namespace Householder.Server.Commands
{
    public class UpdateSettlementStatusCommandHandler : ICommandHandler<UpdateSettlementStatusCommand, bool>
    {
        private MySqlDatabase database;

        public UpdateSettlementStatusCommandHandler(MySqlDatabase database)
        {
            this.database = database;
        }

        public async Task<bool> Handle(UpdateSettlementStatusCommand command)
        {
            var results = new List<Expense>();
            var id = command.ID;
            var settlementStatus = command.SettlementStatus;

            var cmd = database.Connection.CreateCommand();

            cmd.CommandText = @"UPDATE `settlement` SET `status_id` = @settlementStatus WHERE `id` = @id";

            cmd.Parameters.Add(new MySqlParameter("@id", id));
            cmd.Parameters.Add(new MySqlParameter("@settlementStatus", (int)settlementStatus));

            var affectedRows = await cmd.ExecuteNonQueryAsync();

            return (affectedRows == 1);
        }
    }
}