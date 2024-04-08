using Mediator;

namespace DataExplorer.Api.Commands.ExecuteSql;

public class ExecuteSqlHandler : IRequestHandler<ExecuteSqlRequest, ExecuteSqlResponse>
{

    public async ValueTask<ExecuteSqlResponse> Handle(ExecuteSqlRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}