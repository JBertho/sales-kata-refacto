namespace SalesReporter.Cli2;

public class ConsoleLogger: ILogger
{
    public void printLine(string output)
    {
        Console.WriteLine(output);
    }
}