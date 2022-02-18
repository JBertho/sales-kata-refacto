namespace SalesReporter.Cli2;

public class ReportParser: IParser
{
    public void Handle(string[] lines, ILogger logger)
    {
        //get all the lines without the header in the first line    
			string[] dataLines = lines[1..(lines.Length)];    
			//declare variables for our conters    
			int salesCount = 0, totalItemsSold = 0;    
			double AverageAmountPerSale = 0.0, AverageItemPriceSold = 0.0, AmountOfAllSales = 0;    
			HashSet<string> clients = new HashSet<string>();    
			DateTime LastCellDate = DateTime.MinValue;    
			//do the counts for each line    
			foreach (var line in dataLines)    
			{ 
				//get the cell values for the line    
				var cells = line.Split(',');    
				salesCount++;//increment the total of sales    
				//to count the number of clients, we put only distinct names in a hashset 
				//then we'll count the number of entries 
				if (!clients.Contains(cells[1])) clients.Add(cells[1]);    
				totalItemsSold += int.Parse(cells[2]);//we sum the total of items sold here    
				AmountOfAllSales += double.Parse(cells[3]);//we sum the amount of each sell    
				//we compare the current cell date with the stored one and pick the higher
				LastCellDate = DateTime.Parse(cells[4]) > LastCellDate ? DateTime.Parse(cells[4]) : LastCellDate;    
			}   
			//we compute the average basket amount per sale    
			AverageAmountPerSale = Math.Round(AmountOfAllSales / salesCount,2);    
			//we compute the average item price sold    
			AverageItemPriceSold = Math.Round(AmountOfAllSales / totalItemsSold,2);    
			logger.printLine($"+{new String('-',45)}+");  
			logger.printLine($"| {" Number of sales".PadLeft(30)} | {salesCount.ToString().PadLeft(10)} |");  
			logger.printLine($"| {" Number of clients".PadLeft(30)} | {clients.Count.ToString().PadLeft(10)} |");  
			logger.printLine($"| {" Total items sold".PadLeft(30)} | {totalItemsSold.ToString().PadLeft(10)} |");  
			logger.printLine($"| {" Total sales amount".PadLeft(30)} | {Math.Round(AmountOfAllSales,2).ToString().PadLeft(10)} |");  
			logger.printLine($"| {" Average amount/sale".PadLeft(30)} | {AverageAmountPerSale.ToString().PadLeft(10)} |");  
			logger.printLine($"| {" Average item price".PadLeft(30)} | {AverageItemPriceSold.ToString().PadLeft(10)} |");  
			logger.printLine($"+{new String('-',45)}+");  
    }
}