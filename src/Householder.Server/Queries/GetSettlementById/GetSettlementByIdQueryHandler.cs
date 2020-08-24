using System.Collections.Generic;
using System.Threading.Tasks;
using Householder.Server.DataAccess;
using Householder.Server.Models;
using MySqlConnector;

namespace Householder.Server.Queries
{
    public class GetSettlementByIdQueryHandler : IQueryHandler<GetSettlementByIdQuery, Settlement>
    {
        private MySqlDatabase database;

        public GetSettlementByIdQueryHandler(MySqlDatabase database)
        {
            this.database = database;
        }

        public async Task<Settlement> Handle(GetSettlementByIdQuery query)
        {
            var results = new List<Settlement>();
            var id = query.SettlementId;

            var cmd = database.Connection.CreateCommand();

            cmd.CommandText = @"SELECT s.id, r.name AS creditor_name, r.name AS debtor_name, s.amount, s.status_id FROM `settlement` s NATURAL JOIN `resident` r WHERE s.id = @id;";

            cmd.Parameters.Add(new MySqlParameter("@id", id));

            var reader = await cmd.ExecuteReaderAsync();

            return new Settlement(
                reader.GetInt32("id"),
                new Resident(reader.GetString("creditor_name")),
                new Resident(reader.GetString("debtor_name")),
                reader.GetDouble("amount"),
                (SettlementStatus)reader.GetInt32("status_id")
            );
        }
    }
}