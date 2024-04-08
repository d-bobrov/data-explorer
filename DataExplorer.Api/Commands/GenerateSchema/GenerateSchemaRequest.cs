using Mediator;

namespace DataExplorer.Api.Commands.GenerateSchema;

public record GenerateSchemaRequest(Guid connectionId) : IRequest<GenerateSchemaResponse>
{
}