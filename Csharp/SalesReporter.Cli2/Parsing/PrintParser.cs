using SalesReporter.Cli2.model;

namespace SalesReporter.Cli2;

public class PrintParser: IParser
{
    public void Handle(string[] lines, ILogger logger)
    {
        string headerLine = lines[0];    
        string[] dataLines = lines[1..(lines.Length)];  
        var columnInfos = new List<Column>();  
        foreach (var columName in headerLine.Split(','))  
        { 
            columnInfos.Add(new Column(columName));  
        }

        var headerString = String.Join(" | ", columnInfos.Select(x => x.GetSoftpaddingLeftName()));
        displayHeader(headerString, logger);
        
        foreach (string line in dataLines)    
        {   
            var tableLine  = String.Join(" | ",   
                line.Split(',').Select(  
                    (val,ind) => val.PadLeft(16)));
            displayLine(tableLine, logger);
        }

        displayEndTab(logger,headerString.Length+2);
    }

    private void displayEndTab(ILogger logger, int spacing)
    {
        logger.printLine("+" + new String('-', spacing) + "+"); 
    }

    private void displayLine(string tableLine, ILogger logger)
    {
        logger.printLine($"| {tableLine} |");
    }

    private void displayHeader(string headerString, ILogger logger)
    {
        logger.printLine("+" + new String('-', headerString.Length + 2) + "+");  
        logger.printLine("| " + headerString + " |");  
        logger.printLine("+" + new String('-', headerString.Length +2 ) + "+"); 
    }
}