namespace SalesReporter.Cli2.model;

public class Column
{
    //int index, int size, string name
    public string name { get;}

    public Column( string name)
    {
        this.name = name;
    }

    public string GetSoftpaddingLeftName()
    {
        return name.PadLeft(16);
    }
}