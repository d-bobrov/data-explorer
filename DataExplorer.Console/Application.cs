using System.Reflection.Metadata.Ecma335;
using DataExplorer.Common.SchemaGenerators;
using DataExplorer.Common.SchemaGenerators.Models;
using DataExplorer.Common.SchemaGenerators.Sqlite;
using Microsoft.Data.Sqlite;

namespace DataExplorer.Console;

public class Application
{

    public async Task Run(string[] args)
    {
        // The first argument contains connection string
        if (args.Length == 0 || string.IsNullOrEmpty(args[0]))
        {
            throw new Exception("Connection string was not provided. Pass your connection string as the first argument");
        }

        string connectionString = args[0];
        System.Console.WriteLine("Starting...");
        System.Console.WriteLine($"The following connection string will be used: {connectionString}");
        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();
        BaseSchemaGenerator schemaGenerator = new SqliteSchemaGenerator(connection);
        System.Console.WriteLine("Retrieving database schema...");
        DatabaseSchema databaseSchema = await schemaGenerator.Generate();
        List<DatabaseTable> tables = new();
        List<DatabaseTable> views = new();
        foreach (var table in databaseSchema.Tables)
        {
            if (table.IsView)
            {
                views.Add(table);
            }
            else
            {
                tables.Add(table);
            }
        }

        System.Console.WriteLine($"Found {(tables.Count == 1 ? "1 table" : $"{tables.Count} tables")} and {(views.Count == 1 ? "1 view" : $"{views.Count} views")}");

        UserQueryDispatcher userQueryDispatcher = new();
        userQueryDispatcher.OnNaturalQuery = async (string query) => { System.Console.WriteLine($"Handling natural query: {query}"); };
        userQueryDispatcher.OnRawQuery = async (string query) => { System.Console.WriteLine($"Raw query: {query}"); };
        userQueryDispatcher.OnExplainQuery = async (string query) => { System.Console.WriteLine($"Explain query: {query}"); };

        _DisplayWelcomeMessage();
        string? input;
        do
{
    System.Console.WriteLine("Enter your query: ");
    input = System.Console.ReadLine();
    if (!string.IsNullOrEmpty(input) && !input.Equals("/q", StringComparison.OrdinalIgnoreCase) && !input.Equals("/quit", StringComparison.OrdinalIgnoreCase))
    {
        await userQueryDispatcher.Dispatch(input);
    }
} while (!input.Equals("/q", StringComparison.OrdinalIgnoreCase) && !input.Equals("/quit", StringComparison.OrdinalIgnoreCase));
    }

    private void _DisplayWelcomeMessage()
    {
        System.Console.WriteLine("Welcome to Data Explorer!");
        System.Console.WriteLine("Here's how you can use this application:");
        System.Console.WriteLine("- To explore data using natural language, simply type your query and press Enter.");
        System.Console.WriteLine("- To explore data using SQL, type '@' followed by your SQL query and press Enter.");
        System.Console.WriteLine("- To get an explanation for your SQL query without executing it, type '?' followed by your query and press Enter.");
        System.Console.WriteLine("- To quit the application, type '/q' or '/quit' and press Enter.");
        System.Console.WriteLine("Enjoy exploring your data!");
    }

}