using System.Collections.Generic;
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

        public System.Threading.Tasks.Task<IEnumerable<Expense>> Handle(GetAllExpensesQuery query)
        {
            var results = new List<Expense>();
            var limit = query.Limit;

            var cmd = database.Connection.CreateCommand();

            cmd.CommandText = @"SELECT * FROM `resident` LIMIT @limit";

            cmd.Parameters.Add(new MySqlParameter("@limit", limit));

            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                
            }
        }
    }
}