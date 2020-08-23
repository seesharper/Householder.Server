using System.Collections.Generic;
using System.Threading.Tasks;
using Householder.Server.DataAccess;
using Householder.Server.Models;
using MySqlConnector;

namespace Householder.Server.Queries
{
    public class GetAllExpensesQueryHandler : IQueryHandler<GetAllExpensesQuery, IEnumerable<Expense>>
    {
        private MySqlDatabase database;

        public GetAllExpensesQueryHandler(MySqlDatabase database)
        {
            this.database = database;
        }

        public async Task<IEnumerable<Expense>> Handle(GetAllExpensesQuery query)
        {
            var results = new List<Expense>();
            var limit = query.Limit;

            var cmd = database.Connection.CreateCommand();

            cmd.CommandText = @"SELECT r.id, r.name AS resident_name, e.amount, e.transaction_date, e.note, e.status_id FROM `expense` e NATURAL JOIN `resident` r LIMIT @limit;";

            cmd.Parameters.Add(new MySqlParameter("@limit", limit));

            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                results.Add(new Expense(
                    reader.GetInt32("id"),
                    new Resident(reader.GetString("resident_name")),
                    reader.GetDouble("amount"),
                    reader.GetDateTime("transaction_date"),
                    reader.GetString("note"),
                    (ExpenseStatus)reader.GetInt32("status_id")
                ));
            }

            return results;
        }
    }
}