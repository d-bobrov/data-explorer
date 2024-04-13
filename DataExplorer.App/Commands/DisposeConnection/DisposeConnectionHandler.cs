using DataExplorer.App.Services.Interfaces;
using Mediator;

namespace DataExplorer.App.Commands.DisposeConnection;

public class DisposeConnectionHandler : IRequestHandler<DisposeConnectionRequest, DisposeConnectionResponse>
{

    private readonly IConnectionManager _connectionManager;

    public DisposeConnectionHandler(IConnectionManager connectionManager)
    {
        _connectionManager = connectionManager;
    }

    public async ValueTask<DisposeConnectionResponse> Handle(DisposeConnectionRequest request, CancellationToken cancellationToken)
    {
        await _connectionManager.DisposeConnection(request.ConnectionId);
        return new DisposeConnectionResponse();
    }
}