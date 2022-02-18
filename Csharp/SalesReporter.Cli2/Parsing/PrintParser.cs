using SalesReporter.Cli2.model;

namespace SalesReporter.Cli2;

public class PrintParser: IParser
{
    public void Handle(string[] lines, ILogger logger)
    {
        var headerLine = lines[0];    
        var dataLines = lines[1..(lines.Length)];
        var columnInfos = GenerateColumns(headerLine);

        var headerString = String.Join(" | ", columnInfos.Select(x => x.GetSoftpaddingLeftName()));
        displayHeader(headerString, logger);

        var tableLines = generateTableLines(dataLines);
        foreach (var tableLine in tableLines)
        {
            displayLine(tableLine, logger);
        }
        displayEndTab(logger,headerString.Length+2);
    }

    private List<string> generateTableLines(string[] dataLines)
    {
        var tableLines = new List<string>();
        foreach (string line in dataLines)
        {
            tableLines.Add(String.Join(" | ",
                line.Split(',').Select(
                    (val, ind) => val.PadLeft(16))));
        }

        return tableLines;
    }

    private List<Column> GenerateColumns(string headerLine)
    {
        var columnInfos = new List<Column>();
        foreach (var columName in headerLine.Split(','))  
        { 
            columnInfos.Add(new Column(columName));  
        }

        return columnInfos;
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