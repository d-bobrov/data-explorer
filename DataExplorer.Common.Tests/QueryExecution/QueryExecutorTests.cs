using System.Data.Common;
using Dapper;
using DataExplorer.Common.QueryExecution;
using FluentAssertions;
using Microsoft.Data.Sqlite;

namespace DataExplorer.Common.Tests.QueryExecution
{
    public class QueryExecutorTests : IDisposable
    {
        private DbConnection _connection;
        private QueryExecutor _queryExecutor;

        public QueryExecutorTests()
        {
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();
            _queryExecutor = new(_connection);

            string createTableQuery = "CREATE TABLE Test (Id INTEGER PRIMARY KEY, Name TEXT);";
            string insertDataQuery = "INSERT INTO Test (Name) VALUES ('TestName');";
            _connection.Execute(createTableQuery);
            _connection.Execute(insertDataQuery);
        }

        public void Dispose()
        {
            _connection.Close();
        }

        [Fact]
        public async Task QueryExecutor_ShouldExecuteRawSqlQueriesAndReturnNonEmptyResult()
        {
            IEnumerable<dynamic> result = await _queryExecutor.ExecuteQueryAsync("SELECT * FROM Test;");
            result.Should().NotBeEmpty();
        }

        [Fact]
        public async Task QueryExecutor_ShouldIncludeColumnNamesInResult()
        {
            IEnumerable<dynamic> result = await _queryExecutor.ExecuteQueryAsync("SELECT * FROM Test;");
            IDictionary<string, object> firstRow = result.First();
            ICollection<string> columnNames = ((IDictionary<string, object>)firstRow).Keys;
            columnNames.Should().Contain(new[] { "Id", "Name" });
        }
    }
}