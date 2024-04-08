using Mediator;

namespace DataExplorer.App.Commands.TranslateNaturalLanguageToSql;

public class TranslateNaturalLanguageToSqlHandler : IRequestHandler<TranslateNaturalLanguageToSqlRequest, TranslateNaturalLanguageToSqlResponse>
{

    public async ValueTask<TranslateNaturalLanguageToSqlResponse> Handle(TranslateNaturalLanguageToSqlRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}