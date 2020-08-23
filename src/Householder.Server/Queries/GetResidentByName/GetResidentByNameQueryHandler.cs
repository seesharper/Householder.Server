using System.Collections.Generic;
using System.Threading.Tasks;
using Householder.Server.DataAccess;
using Householder.Server.Models;
using MySqlConnector;

namespace Householder.Server.Queries
{
    public class GetResidentByNameQueryHandler : IQueryHandler<GetResidentByNameQuery, Resident>
    {
        private MySqlDatabase database;

        public GetResidentByNameQueryHandler(MySqlDatabase database)
        {
            this.database = database;
        }
        
        public async Task<Resident> Handle(GetResidentByNameQuery query)
        {
            var name = query.Name;

            var cmd = database.Connection.CreateCommand();

            cmd.CommandText = @"SELECT id, name FROM `resident` WHERE name=@name";

            cmd.Parameters.Add(new MySqlParameter("@name", name));

            var reader = await cmd.ExecuteReaderAsync();

            await reader.ReadAsync();

            return new Resident(
                reader.GetInt32("id"),
                reader.GetString("name")
            );
        }
    }
}