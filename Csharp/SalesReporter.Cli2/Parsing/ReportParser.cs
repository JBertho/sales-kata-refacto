using SalesReporter.Cli2.model;

namespace SalesReporter.Cli2;

public class ReportParser: IParser
{
    public void Handle(string[] lines, ILogger logger)
    {
	    string[] dataLines = lines[1..(lines.Length)];
	    Report report = new Report();

	    foreach (var line in dataLines)
	    {
		    var cells = line.Split(',');
		    report.AddSale();
		    if (!report.ContainClient(cells[1]))
			    report.addClient(cells[1]);
		    report.AddItemSold(int.Parse(cells[2]));
		    report.AddAmountOfAll(double.Parse(cells[3]));
	    }

	    displayReport(report, logger);
    }

    private void displayReport(Report report,
								ILogger logger)
    {
	    logger.printLine($"+{new String('-',45)}+");  
	    logger.printLine($"| {" Number of sales".PadLeft(30)} | {report.SalesCount.ToString().PadLeft(10)} |");  
	    logger.printLine($"| {" Number of clients".PadLeft(30)} | {report.GetClientCount().ToString().PadLeft(10)} |");  
	    logger.printLine($"| {" Total items sold".PadLeft(30)} | {report.TotalItemsSold.ToString().PadLeft(10)} |");  
	    logger.printLine($"| {" Total sales amount".PadLeft(30)} | {report.GetRoundedAmountOfAllSales().ToString().PadLeft(10)} |");  
	    logger.printLine($"| {" Average amount/sale".PadLeft(30)} | {report.GetAverageAmountPerSale().ToString().PadLeft(10)} |");  
	    logger.printLine($"| {" Average item price".PadLeft(30)} | {report.GetAverageItemPriceSold().ToString().PadLeft(10)} |");  
	    logger.printLine($"+{new String('-',45)}+");  
    }
}