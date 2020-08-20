using System;
using MySqlConnector;

namespace Householder.Server.DataAccess
{
    public class MySqlDatabase : IDisposable
    {
        public MySqlConnection Connection { get; }

        public MySqlDatabase(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}