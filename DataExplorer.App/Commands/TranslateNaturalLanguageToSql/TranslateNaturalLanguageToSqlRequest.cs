using DataExplorer.App.Models;
using DataExplorer.Common.SchemaGenerators.Models;
using Mediator;

namespace DataExplorer.App.Commands.TranslateNaturalLanguageToSql;

public record TranslateNaturalLanguageToSqlRequest(ConnectionModel Connection, DatabaseSchema DatabaseSchema, string Prompt) : IRequest<TranslateNaturalLanguageToSqlResponse>
{
}