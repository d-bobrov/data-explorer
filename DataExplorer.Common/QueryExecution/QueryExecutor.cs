using System.Data.Common;
using Dapper;

namespace DataExplorer.Common.QueryExecution;

public class QueryExecutor : IQueryExecutor
{

    private readonly DbConnection _connection;

    public QueryExecutor(DbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<dynamic>> ExecuteQueryAsync(string query)
    {
            return await _connection.QueryAsync<dynamic>(query);
    }
}