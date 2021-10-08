using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace BimKrav.Server
{
    public class MySqlDbConnection : IMySqlDbConnection
    {
        private readonly MySqlConnection _connection;
        private readonly ILogger<MySqlDbConnection> _logger;

        public MySqlDbConnection(MySqlConnection connection, ILogger<MySqlDbConnection> logger)
        {
            _connection = connection;
            _logger = logger;
        }
        public async Task<List<T>> ExecuteQuery<T>(string sql, CancellationToken cancellationToken = default)
        {
            await _connection.OpenAsync(cancellationToken);
            try
            {
                return (await _connection.QueryAsync<T>(sql)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to execute query", sql);
                throw;
            }
            finally
            {

                await _connection.CloseAsync();
            }
        }
    }
}