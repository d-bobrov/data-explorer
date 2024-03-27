using DataExplorer.Common.SchemaGenerators.Models;

namespace DataExplorer.Common.SchemaGenerators;

public abstract class BaseSchemaGenerator
{

    protected readonly string _connectionString;

    protected BaseSchemaGenerator(string connectionString)
    {
        _connectionString = connectionString;
    }

    public abstract Task<DatabaseSchema> Generate();


}