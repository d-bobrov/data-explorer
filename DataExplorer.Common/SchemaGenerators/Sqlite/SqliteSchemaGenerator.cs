using System.Data.Common;
using Dapper;
using DataExplorer.Common.SchemaGenerators.Models;
using DataExplorer.Common.SchemaGenerators.Sqlite.Entities;

namespace DataExplorer.Common.SchemaGenerators.Sqlite;

public class SqliteSchemaGenerator : BaseSchemaGenerator
{

    private const string FetchTablesViewsQuery = "SELECT type AS Type, name AS Name, tbl_name AS TblName, sql AS Sql FROM sqlite_schema WHERE type = 'table' OR type = 'view'";
    private const string FetchColumns = "SELECT name AS Name, type AS Type, \"notnull\" AS IsNullable, dflt_value AS DefaultValue, pk AS PrimaryKeyIndex FROM pragma_table_info(:table)";
    public SqliteSchemaGenerator(DbConnection connection) : base(connection)
    {
    }

    public override async Task<DatabaseSchema> Generate()
    {
        DatabaseSchema result = new()
        {
            Tables = new List<DatabaseTable>()
        };
        List<SchemaTable> tablesViews = (await _connection.QueryAsync<SchemaTable>(FetchTablesViewsQuery)).ToList();
        if (tablesViews.Count > 0)
        {
            foreach (var tableView in tablesViews)
            {
                var parameters = new Dictionary<string, object>()
               {
                   {
                       "table", tableView.Name
                   }
               };
                List<ColumnInfo> columns = (await _connection.QueryAsync<ColumnInfo>(FetchColumns, parameters)).ToList();
                tableView.Columns = columns;
            }
            result.Tables = _mapTables(tablesViews);

        }

        return result;
    }

    private List<DatabaseTable> _mapTables(List<SchemaTable> tablesFromDb)
    {
        List<DatabaseTable> result = new();
        foreach (var tableFromDb in tablesFromDb)
        {
            result.Add(new()
            {
                Name = tableFromDb.Name,
                Columns = _mapColumns(tableFromDb.Columns),
                Sql = tableFromDb.Sql,
                IsView = tableFromDb.Type == "view" ? true : false
            });
        }
        return result;
    }

    private List<TableColumn> _mapColumns(List<ColumnInfo> columnsFromDb)
    {
        List<TableColumn> result = new();
        foreach (var columnFromDb in columnsFromDb)
        {
            result.Add(new TableColumn()
            {
                Name = columnFromDb.Name,
                DataType = columnFromDb.Type,
                IsPrimaryKey = columnFromDb.PrimaryKeyIndex > 0 ? true : false,
            });
        }
        return result;
    }

}