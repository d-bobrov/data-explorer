using Mediator;

namespace DataExplorer.App.Commands.GenerateSchema;

public record GenerateSchemaRequest(Guid connectionId) : IRequest<GenerateSchemaResponse>
{
}