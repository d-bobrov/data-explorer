using System.Data.Common;
using DataExplorer.Common.SchemaGenerators.Models;

namespace DataExplorer.Common.SchemaGenerators;

public abstract class BaseSchemaGenerator
{

    protected readonly DbConnection _connection;

    protected BaseSchemaGenerator(DbConnection connection)
    {
        _connection = connection;
    }

    public abstract Task<DatabaseSchema> Generate();


}