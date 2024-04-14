using Mediator;

namespace DataExplorer.App.Commands.CreateConnection;

public record CreateConnectionRequest(string ConnectionString) : IRequest<CreateConnectionResponse>
{
}