using Mediator;

namespace DataExplorer.Api.Commands.CreateConnection;

public record CreateConnectionRequest(string ConnectionString) : IRequest<CreateConnectionResponse>
{
}