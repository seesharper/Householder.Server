using System.Threading.Tasks;
using Householder.Server.DataAccess;
using Householder.Server.Models;
using MySqlConnector;

namespace Householder.Server.Commands
{
    public class AddExpenseCommandHandler : ICommandHandler<AddExpenseCommand, long>
    {
        private MySqlDatabase database;

        public AddExpenseCommandHandler(MySqlDatabase database)
        {
            this.database = database;
        }

        public async Task<long> Handle(AddExpenseCommand command)
        {
            var expense = command.Expense;

            var cmd = database.Connection.CreateCommand();

            cmd.CommandText = @"INSERT INTO `expense` (`resident_id`, `amount`, `transaction_date`, `note`) VALUES (@residentId, @amount, @transactionDate, @note)";

            cmd.Parameters.Add(new MySqlParameter("@residentId", expense.Payee.ID));
            cmd.Parameters.Add(new MySqlParameter("@amount", expense.Amount));
            cmd.Parameters.Add(new MySqlParameter("@transactioNDate", expense.Date));
            cmd.Parameters.Add(new MySqlParameter("@note", expense.Note));

            await cmd.ExecuteNonQueryAsync();

            return cmd.LastInsertedId;
        }
    }
}