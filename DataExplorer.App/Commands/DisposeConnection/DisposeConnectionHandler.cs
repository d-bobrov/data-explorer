using Mediator;

namespace DataExplorer.App.Commands.DisposeConnection;

public class DisposeConnectionHandler : IRequestHandler<DisposeConnectionRequest, DisposeConnectionResponse>
{

    public async ValueTask<DisposeConnectionResponse> Handle(DisposeConnectionRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}