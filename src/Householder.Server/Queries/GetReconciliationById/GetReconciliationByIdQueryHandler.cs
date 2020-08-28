
using System.Threading.Tasks;
using Householder.Server.DataAccess;
using Householder.Server.Models;
using MySqlConnector;

namespace Householder.Server.Queries
{
    public class GetReconciliationByIdQueryHandler : IQueryHandler<GetReconciliationByIdQuery, Reconciliation>
    {
        private MySqlDatabase database;

        public GetReconciliationByIdQueryHandler(MySqlDatabase database)
        {
            this.database = database;
        }

        public async Task<Reconciliation> Handle(GetReconciliationByIdQuery query)
        {
            var id = query.ID;

            var cmd = database.Connection.CreateCommand();

            cmd.CommandText = @"SELECT r.id, r1.name AS creator_name, r1.creation_date FROM `reconciliation` r NATURAL JOIN `resident` r1 WHERE r.id = @id;";

            cmd.Parameters.Add(new MySqlParameter("@id", id));

            var reader = await cmd.ExecuteReaderAsync();

            await reader.ReadAsync();

            return new Reconciliation(
                reader.GetInt32("id"),
                new Resident(reader.GetString("creator_name")),
                reader.GetDateTime("creation_date")
            );
        }
    }
}