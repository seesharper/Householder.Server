using System.Collections.Generic;
using System.Threading.Tasks;
using Householder.Server.DataAccess;
using Householder.Server.Models;
using MySqlConnector;

namespace Householder.Server.Queries
{
    public class GetAllReconciliationsQueryHandler : IQueryHandler<GetAllReconciliationsQuery, IEnumerable<Reconciliation>>
    {
        private MySqlDatabase database;

        public GetAllReconciliationsQueryHandler(MySqlDatabase database)
        {
            this.database = database;
        }

        public async Task<IEnumerable<Reconciliation>> Handle(GetAllReconciliationsQuery query)
        {
            var results = new List<Reconciliation>();
            var limit = query.Limit;

            var cmd = database.Connection.CreateCommand();

            cmd.CommandText = @"SELECT r.id, r1.name AS creator_name, r1.creation_date FROM `reconciliation` r NATURAL JOIN `resident` r1 LIMIT @limit;";

            cmd.Parameters.Add(new MySqlParameter("@limit", limit));

            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                results.Add(new Reconciliation(
                    reader.GetInt32("id"),
                    new Resident(reader.GetString("creator_name")),
                    reader.GetDateTime("creation_date")
                ));
            }

            return results;
        }
    }
}