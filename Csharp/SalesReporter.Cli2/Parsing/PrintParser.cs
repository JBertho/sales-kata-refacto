namespace SalesReporter.Cli2;

public class PrintParser: IParser
{
    public void Handle(string[] lines, ILogger logger)
    {
        //get the header line    
        string headerLine = lines[0];    
        //get other content lines    
        string[] dataLines = lines[1..(lines.Length)];  
        var columnInfos = new List<(int index, int size, string name)>();  
        //build the header of the table with column names from our data file    
        int i = 0;  
        foreach (var columName in headerLine.Split(','))  
        { 
            columnInfos.Add((i++, columName.Length, columName));  
        }  
        var headerString  = String.Join(  " | ",   
            columnInfos.Select(x=>x.name).Select(  
                (val,ind) => val.PadLeft(16)));  
        logger.printLine("+" + new String('-', headerString.Length + 2) + "+");  
        logger.printLine("| " + headerString + " |");  
        logger.printLine("+" + new String('-', headerString.Length +2 ) + "+");  

        //then add each line to the table    
        foreach (string line in dataLines)    
        {   
            //extract columns from our csv line and add all these cells to the line    
            var tableLine  = String.Join(" | ",   
                line.Split(',').Select(  
                    (val,ind) => val.PadLeft(16)));  
            logger.printLine($"| {tableLine} |");  
        }
			
        logger.printLine("+" + new String('-', headerString.Length+2) + "+"); 
    }
}