using Mediator;

namespace DataExplorer.Api.Commands.TranslateNaturalLanguageToSql;

public class TranslateNaturalLanguageToSqlHandler : IRequestHandler<TranslateNaturalLanguageToSqlRequest, TranslateNaturalLanguageToSqlResponse>
{

    public async ValueTask<TranslateNaturalLanguageToSqlResponse> Handle(TranslateNaturalLanguageToSqlRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}