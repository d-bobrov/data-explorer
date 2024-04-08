using Mediator;

namespace DataExplorer.Api.Commands.DisposeConnection;

public class DisposeConnectionHandler : IRequestHandler<DisposeConnectionRequest, DisposeConnectionResponse>
{

    public async ValueTask<DisposeConnectionResponse> Handle(DisposeConnectionRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}