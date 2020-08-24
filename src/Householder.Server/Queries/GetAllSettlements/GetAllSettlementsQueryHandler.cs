using System.Collections.Generic;
using System.Threading.Tasks;
using Householder.Server.DataAccess;
using Householder.Server.Models;
using MySqlConnector;

namespace Householder.Server.Queries
{
    public class GetAllSettlementsQueryHandler : IQueryHandler<GetAllSettlementsQuery, IEnumerable<Settlement>>
    {
        private MySqlDatabase database;

        public GetAllSettlementsQueryHandler(MySqlDatabase database)
        {
            this.database = database;
        }

        public async Task<IEnumerable<Settlement>> Handle(GetAllSettlementsQuery query)
        {
            var results = new List<Settlement>();
            var limit = query.Limit;

            var cmd = database.Connection.CreateCommand();

            cmd.CommandText = @"SELECT s.id, r.name AS creditor_name, r.name AS debtor_name, s.amount, s.status_id FROM `settlement` s NATURAL JOIN `resident` r LIMIT @limit;";

            cmd.Parameters.Add(new MySqlParameter("@limit", limit));

            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                results.Add(new Settlement(
                    reader.GetInt32("id"),
                    new Resident(reader.GetString("creditor_name")),
                    new Resident(reader.GetString("debtor_name")),
                    reader.GetDouble("amount"),
                    (SettlementStatus)reader.GetInt32("status_id")
                ));
            }

            return results;
        }
    }
}