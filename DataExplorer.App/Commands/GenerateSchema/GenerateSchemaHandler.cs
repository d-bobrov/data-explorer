using Mediator;

namespace DataExplorer.App.Commands.GenerateSchema;

public class GenerateSchemaHandler : IRequestHandler<GenerateSchemaRequest, GenerateSchemaResponse>
{

    public async ValueTask<GenerateSchemaResponse> Handle(GenerateSchemaRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}