using Mediator;

namespace DataExplorer.App.Commands.ExecuteSql;

public class ExecuteSqlHandler : IRequestHandler<ExecuteSqlRequest, ExecuteSqlResponse>
{

    public async ValueTask<ExecuteSqlResponse> Handle(ExecuteSqlRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}