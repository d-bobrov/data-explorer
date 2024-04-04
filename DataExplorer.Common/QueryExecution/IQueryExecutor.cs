namespace DataExplorer.Common.QueryExecution;

public interface IQueryExecutor
{
        Task<IEnumerable<dynamic>> ExecuteQueryAsync(string query);
}