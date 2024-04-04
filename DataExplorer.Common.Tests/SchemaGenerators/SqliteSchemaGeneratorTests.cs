using System.Data.Common;
using Dapper;
using DataExplorer.Common.SchemaGenerators.Sqlite;
using FluentAssertions;
using Microsoft.Data.Sqlite;

namespace DataExplorer.Common.Tests.SchemaGenerators;

public class SqliteSchemaGeneratorTests : IDisposable
{
    private DbConnection _connection;
    private SqliteSchemaGenerator _generator;

    public SqliteSchemaGeneratorTests()
    {
        _connection = new SqliteConnection("Data Source=:memory:");
        _connection.Open();

        _generator = new SqliteSchemaGenerator(_connection);

        var createTablesSql = @"
            CREATE TABLE test_table1 (
                id INTEGER PRIMARY KEY,
                name TEXT NOT NULL,
                age INTEGER
            );

            CREATE TABLE test_table2 (
                id INTEGER PRIMARY KEY,
                address TEXT NOT NULL,
                phone TEXT
            );

            CREATE VIEW test_view AS SELECT * FROM test_table1;
        ";

        _connection.Execute(createTablesSql);
    }

    [Fact]
    public async Task Generate_ShouldReturnEmptySchema_WhenNoTablesOrViewsExist()
    {
        using var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();
        var generator = new SqliteSchemaGenerator(connection);

        var result = await generator.Generate();

        result.Tables.Should().BeEmpty();
    } 
    
    [Fact]
    public async void Generate_ShouldReturnCorrectNumberOfTables()
    {
        var result = await _generator.Generate();
        result.Tables.Count.Should().Be(3);
    }

    [Fact]
    public async void Generate_ShouldReturnCorrectNumberOfColumnsForTable1()
    {
        var result = await _generator.Generate();
        var table1 = result.Tables.First(t => t.Name == "test_table1");
        table1.Columns.Count.Should().Be(3);
    }

    [Fact]
    public async void Generate_ShouldReturnCorrectNumberOfColumnsForTable2()
    {
        var result = await _generator.Generate();
        var table2 = result.Tables.First(t => t.Name == "test_table2");
        table2.Columns.Count.Should().Be(3);
    }

    [Fact]
    public async void Generate_ShouldIdentifyTable1AsNotView()
    {
        var result = await _generator.Generate();
        var table1 = result.Tables.First(t => t.Name == "test_table1");
        table1.IsView.Should().BeFalse();
    }

    [Fact]
    public async void Generate_ShouldIdentifyTable2AsNotView()
    {
        var result = await _generator.Generate();
        var table2 = result.Tables.First(t => t.Name == "test_table2");
        table2.IsView.Should().BeFalse();
    }

    [Fact]
    public async void Generate_ShouldIdentifyTestViewAsView()
    {
        var result = await _generator.Generate();
        var view = result.Tables.First(t => t.Name == "test_view");
        view.IsView.Should().BeTrue();
    }

    [Fact]
    public async void Generate_ShouldHaveSqlForTable1()
    {
        var result = await _generator.Generate();
        var table1 = result.Tables.First(t => t.Name == "test_table1");
        table1.Sql.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async void Generate_ShouldHaveSqlForTable2()
    {
        var result = await _generator.Generate();
        var table2 = result.Tables.First(t => t.Name == "test_table2");
        table2.Sql.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async void Generate_ShouldHaveSqlForTestView()
    {
        var result = await _generator.Generate();
        var view = result.Tables.First(t => t.Name == "test_view");
        view.Sql.Should().NotBeNullOrEmpty();
    }

    public void Dispose()
    {
        _connection?.Dispose();
    }
}