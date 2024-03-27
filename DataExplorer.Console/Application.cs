using System.Reflection.Metadata.Ecma335;

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
    }
    
}