using DataExplorer.Api.Models;
using DataExplorer.Common.SchemaGenerators.Models;
using Mediator;

namespace DataExplorer.Api.Commands.TranslateNaturalLanguageToSql;

public record TranslateNaturalLanguageToSqlRequest(ConnectionModel Connection, DatabaseSchema DatabaseSchema, string Prompt) : IRequest<TranslateNaturalLanguageToSqlResponse>
{
}