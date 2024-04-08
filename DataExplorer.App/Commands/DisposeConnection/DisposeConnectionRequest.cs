using Mediator;

namespace DataExplorer.App.Commands.DisposeConnection;

public record DisposeConnectionRequest(Guid ConnectionId) : IRequest<DisposeConnectionResponse>
{
}