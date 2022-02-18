public static class Program2 
{  
 	public static void Main(string[] args)  
 	{ 
	    //add a title to our app    
		Console.WriteLine("=== Sales Viewer ===");  
		//extract the commandType name from the args    
		string commandType = args.Length > 0 ? args[0] : "unknown";    
		string file = args.Length >= 2 ? args[1] : "./data.csv";  
		 //read content of our data file    
			  //[2012-10-30] rui : actually it only works with this file, maybe it's a good idea to pass file //name as parameter to this app later?    
		string[] dataContentString = File.ReadAllLines(file);    
		//if commandType is print    
		if (commandType == "print")    
      	{    
			//get the header line    
			string headerLine = dataContentString[0];    
			//get other content lines    
			string[] dataLines = dataContentString[1..(dataContentString.Length)];  
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
			Console.WriteLine("+" + new String('-', headerString.Length + 2) + "+");  
			Console.WriteLine("| " + headerString + " |");  
			Console.WriteLine("+" + new String('-', headerString.Length +2 ) + "+");  

			 //then add each line to the table    
			foreach (string line in dataLines)    
			{   
				//extract columns from our csv line and add all these cells to the line    
			 	var tableLine  = String.Join(" | ",   
						line.Split(',').Select(  
			 				(val,ind) => val.PadLeft(16)));  
			 	Console.WriteLine($"| {tableLine} |");  
			}
			
			Console.WriteLine("+" + new String('-', headerString.Length+2) + "+");  
			// if commandType is report  
		}   
		else if (commandType == "report")    
		{    
			//get all the lines without the header in the first line    
			string[] dataLines = dataContentString[1..(dataContentString.Length)];    
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
			Console.WriteLine($"+{new String('-',45)}+");  
			Console.WriteLine($"| {" Number of sales".PadLeft(30)} | {salesCount.ToString().PadLeft(10)} |");  
			Console.WriteLine($"| {" Number of clients".PadLeft(30)} | {clients.Count.ToString().PadLeft(10)} |");  
			Console.WriteLine($"| {" Total items sold".PadLeft(30)} | {totalItemsSold.ToString().PadLeft(10)} |");  
			Console.WriteLine($"| {" Total sales amount".PadLeft(30)} | {Math.Round(AmountOfAllSales,2).ToString().PadLeft(10)} |");  
			Console.WriteLine($"| {" Average amount/sale".PadLeft(30)} | {AverageAmountPerSale.ToString().PadLeft(10)} |");  
			Console.WriteLine($"| {" Average item price".PadLeft(30)} | {AverageItemPriceSold.ToString().PadLeft(10)} |");  
			Console.WriteLine($"+{new String('-',45)}+");  
		}
		else    
		{    
			Console.WriteLine("[ERR] your commandType is not valid ");    
			Console.WriteLine("Help: ");    
			Console.WriteLine("    - [print]  : show the content of our commerce records in data.csv");    
			Console.WriteLine("    - [report] : show a summary from data.csv records ");    
		}  
 }}
