using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using DataExplorer.App.Services.Interfaces;

namespace DataExplorer.App.Services;

public class ConnectionManager : IConnectionManager
{

    private readonly Dictionary<Guid, DbConnection> _connections = new();

    public async Task<Guid> CreateSqliteConnection(string connectionString)
    {
        var connectionId = Guid.NewGuid();

        var newConnection = new SqliteConnection(connectionString);
        await newConnection.OpenAsync();

        _connections[connectionId] = newConnection;

        return connectionId;
    }

    public Task<DbConnection> GetConnection(Guid connectionId)
    {
        if (_connections.TryGetValue(connectionId, out var connection))
        {
            return Task.FromResult(connection);
        }

        throw new KeyNotFoundException($"No connection found with ID {connectionId}");
    }

    public async Task DisposeConnection(Guid connectionId)
    {
        if (_connections.TryGetValue(connectionId, out var connection))
        {
            await connection.CloseAsync();
            connection.Dispose();

            _connections.Remove(connectionId);
        }
        else
        {
            throw new KeyNotFoundException($"No connection found with ID {connectionId}");
        }
    }
}