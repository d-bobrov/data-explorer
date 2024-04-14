using System.Data.Common;
using DataExplorer.App.Services.Interfaces;
using DataExplorer.Common.SchemaGenerators;
using DataExplorer.Common.SchemaGenerators.Models;
using Mediator;

namespace DataExplorer.App.Commands.GenerateSchema;

public class GenerateSchemaHandler : IRequestHandler<GenerateSchemaRequest, GenerateSchemaResponse>
{

    private readonly ISchemaGeneratorFactory _schemaGeneratorFactory;
    private readonly IConnectionManager _connectionManager;

    public GenerateSchemaHandler(ISchemaGeneratorFactory schemaGeneratorFactory, IConnectionManager connectionManager)
    {
        _schemaGeneratorFactory = schemaGeneratorFactory;
        _connectionManager = connectionManager;
    }

    public async ValueTask<GenerateSchemaResponse> Handle(GenerateSchemaRequest request, CancellationToken cancellationToken)
    {
        DbConnection connection = await _connectionManager.GetConnection(request.connectionId);
        BaseSchemaGenerator sqliteSchemaGenerator = _schemaGeneratorFactory.CreateSchemaGenerator(DatabaseProvider.Sqlite, connection);
        DatabaseSchema databaseSchema = await sqliteSchemaGenerator.Generate();
        return new GenerateSchemaResponse(databaseSchema);
    }
}