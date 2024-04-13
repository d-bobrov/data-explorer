using System.Data.Common;

namespace DataExplorer.App.Services.Interfaces;

public interface IConnectionManager
{
    Task<Guid> CreateSqliteConnection(string connectionString);
    Task<DbConnection> GetConnection(Guid connectionId);
    Task DisposeConnection(Guid connectionId);

}