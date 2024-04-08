using Mediator;

namespace DataExplorer.Api.Commands.DisposeConnection;

public record DisposeConnectionRequest(Guid ConnectionId) : IRequest<DisposeConnectionResponse>
{
}