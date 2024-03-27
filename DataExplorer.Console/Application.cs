using System.Reflection.Metadata.Ecma335;
using DataExplorer.Common.SchemaGenerators;
using DataExplorer.Common.SchemaGenerators.Models;
using DataExplorer.Common.SchemaGenerators.Sqlite;

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
        System.Console.WriteLine("Welcome to Data Explorer");
       System.Console.WriteLine($"The following connection string will be used: {connectionString}");
       System.Console.WriteLine("Retrieving database schema...");
       BaseSchemaGenerator schemaGenerator = new SqliteSchemaGenerator(connectionString);
       DatabaseSchema databaseSchema =await schemaGenerator.Generate();
    }
    
}