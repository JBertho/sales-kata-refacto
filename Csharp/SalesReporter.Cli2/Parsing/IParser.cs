namespace SalesReporter.Cli2;

public interface IParser
{
    public void Handle(string[] lines,ILogger logger);
}