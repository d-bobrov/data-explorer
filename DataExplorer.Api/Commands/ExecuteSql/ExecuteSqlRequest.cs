using Mediator;

namespace DataExplorer.Api.Commands.ExecuteSql;

public record ExecuteSqlRequest(Guid connectionId, string Sql) : IRequest<ExecuteSqlResponse>
{
}