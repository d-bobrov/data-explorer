using DataExplorer.Common.SchemaGenerators.Models;

namespace DataExplorer.Common.SchemaGenerators.Sqlite;

public class SqliteSchemaGenerator : BaseSchemaGenerator
{
    public SqliteSchemaGenerator(string connectionString) : base(connectionString)
    {
    }

    public override async Task<DatabaseSchema> Generate()
    {
        throw new NotImplementedException();
    }

}