namespace DataExplorer.Console;

class Program
{
    static async Task Main(string[] args)
    {
        var app = new Application();
        try
        {
            await app.Run(args);
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
        }
    }
}