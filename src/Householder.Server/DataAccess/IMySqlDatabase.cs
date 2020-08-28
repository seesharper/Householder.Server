using System;
using MySqlConnector;

namespace Householder.Server.DataAccess
{
    public interface IMySqlDatabase : IDisposable
    {
        MySqlConnection Connection { get; }
    }
}