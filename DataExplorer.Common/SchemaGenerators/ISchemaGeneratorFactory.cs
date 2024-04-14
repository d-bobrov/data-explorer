using System.Data.Common;
using DataExplorer.Common.SchemaGenerators.Models;

namespace DataExplorer.Common.SchemaGenerators;

public interface ISchemaGeneratorFactory
{
    BaseSchemaGenerator CreateSchemaGenerator(DatabaseProvider databaseProvider, DbConnection connection);
}