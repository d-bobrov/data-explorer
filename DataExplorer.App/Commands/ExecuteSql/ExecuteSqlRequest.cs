using Mediator;

namespace DataExplorer.App.Commands.ExecuteSql;

public record ExecuteSqlRequest(Guid connectionId, string Sql) : IRequest<ExecuteSqlResponse>
{
}