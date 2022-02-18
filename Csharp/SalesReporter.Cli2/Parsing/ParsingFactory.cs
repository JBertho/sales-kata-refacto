namespace SalesReporter.Cli2;

public class ParsingFactory
{
    public const string Print = "print";
    public const string Report = "report";
    
    public static IParser get(string command)
    {
        switch (command)
        {
            case Print :
                return new PrintParser();
            case Report :
                return new ReportParser();
            default:
                return new NotFoundParser();
        }
    }
}