using System.Data.Common;
using DataExplorer.Common.SchemaGenerators.Models;
using DataExplorer.Common.SchemaGenerators.Sqlite;

namespace DataExplorer.Common.SchemaGenerators;

public class SchemaGeneratorFactory : ISchemaGeneratorFactory
{
    public BaseSchemaGenerator CreateSchemaGenerator(DatabaseProvider databaseProvider, DbConnection connection)
    {
        return databaseProvider switch
        {
            DatabaseProvider.Sqlite => new SqliteSchemaGenerator(connection),
            _ => throw new NotSupportedException($"{databaseProvider.ToString()} is not supported")
        };
    }
}