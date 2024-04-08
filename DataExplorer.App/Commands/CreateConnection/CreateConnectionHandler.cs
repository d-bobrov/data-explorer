using Mediator;

namespace DataExplorer.App.Commands.CreateConnection;

public class CreateConnectionHandler : IRequestHandler<CreateConnectionRequest, CreateConnectionResponse>
{

    public async ValueTask<CreateConnectionResponse> Handle(CreateConnectionRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}