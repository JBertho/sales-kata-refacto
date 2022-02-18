namespace SalesReporter.Cli2.model;

public class Report
{
    public int SalesCount { get; set; }
    public int TotalItemsSold { get; set; }
    public double AmountOfAllSales { get; set; }
    public HashSet<string> Clients { get; }

    public Report()
    {
        SalesCount = 0;
        TotalItemsSold = 0;
        AmountOfAllSales = 0;
        Clients = new HashSet<string>();
    }

    public void AddSale()
    {
        SalesCount++;
    }

    public bool ContainClient(string newClient)
    {
        return Clients.Contains(newClient);
    }

    public void addClient(string newClient)
    {
        Clients.Add(newClient);    
    }

    public void AddItemSold(int value)
    {
        TotalItemsSold += value;
    }

    public void AddAmountOfAll(double value)
    {
        AmountOfAllSales += value;
    }

    public double GetAverageAmountPerSale()
    {
        return Math.Round(AmountOfAllSales / SalesCount,2);    
    }

    public double GetAverageItemPriceSold()
    {
        return Math.Round(AmountOfAllSales / TotalItemsSold, 2);
    }

    public int GetClientCount()
    {
        return Clients.Count;
    }

    public double GetRoundedAmountOfAllSales()
    {
        return Math.Round(AmountOfAllSales, 2);
    }
}