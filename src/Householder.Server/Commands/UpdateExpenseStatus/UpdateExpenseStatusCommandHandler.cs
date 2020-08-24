using System.Collections.Generic;
using System.Threading.Tasks;
using Householder.Server.DataAccess;
using Householder.Server.Models;
using MySqlConnector;

namespace Householder.Server.Commands
{
    public class UpdateExpenseStatusCommandHandler : ICommandHandler<UpdateExpenseStatusCommand, bool>
    {
        private MySqlDatabase database;

        public UpdateExpenseStatusCommandHandler(MySqlDatabase database)
        {
            this.database = database;
        }

        public async Task<bool> Handle(UpdateExpenseStatusCommand command)
        {
            var results = new List<Expense>();
            var id = command.ID;
            var expenseStatus = command.ExpenseStatus;

            var cmd = database.Connection.CreateCommand();

            cmd.CommandText = @"UPDATE expense SET status_id = @expenseStatus WHERE id = @id";

            cmd.Parameters.Add(new MySqlParameter("@id", id));
            cmd.Parameters.Add(new MySqlParameter("@expenseStatus", (int)expenseStatus));

            var affectedRows = await cmd.ExecuteNonQueryAsync();

            return (affectedRows == 1);
        }
    }
}