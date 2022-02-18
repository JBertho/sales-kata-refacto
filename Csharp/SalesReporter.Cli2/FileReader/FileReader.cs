namespace SalesReporter.Cli2;

public class FileReader: IFileReader
{
    public string[] Read(string file)
    {
        return File.ReadAllLines(file);   
    }
}