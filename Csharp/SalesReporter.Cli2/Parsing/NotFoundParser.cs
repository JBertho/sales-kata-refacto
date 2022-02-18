namespace SalesReporter.Cli2;

public class NotFoundParser: IParser
{
    public void Handle(string[] lines, ILogger logger)
    {
        logger.printLine("[ERR] your commandType is not valid ");    
        logger.printLine("Help: ");    
        logger.printLine("    - [print]  : show the content of our commerce records in data.csv");    
        logger.printLine("    - [report] : show a summary from data.csv records ");  
    }
}