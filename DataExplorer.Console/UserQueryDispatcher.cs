namespace DataExplorer.Console;

public class UserQueryDispatcher
{

    public Func<string, Task> OnNaturalQuery { get; set; }
    public Func<string, Task> OnRawQuery { get; set; }
    public Func<string, Task> OnExplainQuery { get; set; }

    public async Task Dispatch(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            throw new ArgumentException("Query cannot be null or empty", nameof(query));
        }

        switch (query[0])
        {
            case '@':
                if (OnRawQuery != null)
                {
                    await OnRawQuery(query.Substring(1));
                }

                break;

            case '?':
                if (OnExplainQuery != null)
                {
                    await OnExplainQuery(query.Substring(1));
                }

                break;

            default:
                if (OnNaturalQuery != null)
                {
                    await OnNaturalQuery(query);
                }

                break;
        }
    }


}