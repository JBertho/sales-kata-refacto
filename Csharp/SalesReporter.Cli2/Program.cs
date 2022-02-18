using SalesReporter.Cli2;

public static class Program2 
{  
 	public static void Main(string[] args)  
 	{ 
	   Execute(args, new ConsoleLogger(), new FileReader());
 }

    public static void Execute(string[] args, ILogger Logger, IFileReader fileReader)
    {

	    Logger.printLine("=== Sales Viewer ===");  

		string commandType = args.Length > 0 ? args[0] : "unknown";    
		string file = args.Length >= 2 ? args[1] : "./data.csv";  

		string[] dataContentString = fileReader.Read(file);    

		IParser parser = ParsingFactory.get(commandType);
		
		parser.Handle(dataContentString,Logger);
    }
    
}



