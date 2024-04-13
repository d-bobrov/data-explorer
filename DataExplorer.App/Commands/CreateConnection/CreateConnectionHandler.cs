using DataExplorer.App.Models;
using DataExplorer.App.Services.Interfaces;
using Mediator;

namespace DataExplorer.App.Commands.CreateConnection;

public class CreateConnectionHandler : IRequestHandler<CreateConnectionRequest, CreateConnectionResponse>
{

    private readonly IConnectionManager _connectionManager;

    public CreateConnectionHandler(IConnectionManager connectionManager)
    {
        _connectionManager = connectionManager;
    }

    public async ValueTask<CreateConnectionResponse> Handle(CreateConnectionRequest request, CancellationToken cancellationToken)
    {
        Guid connectionId = await _connectionManager.CreateSqliteConnection(request.ConnectionString);
        ConnectionModel connection = new(connectionId);
        return new CreateConnectionResponse(connection);
    }
}