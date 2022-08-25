using System.Text;

class Program
{
    //First task
    //Create class for Data and read chemistry.csv file
    //Display the number of elements in file

    static readonly List<Element> elements = new();

    static void Main()
    {
        ReadCSV();
        Task1();
    }
    private static void ReadCSV()
    {
        foreach (var item in File.ReadAllLines("chemistry.csv", Encoding.UTF8).Skip(1))
        {
            Element element = new(item);
            elements.Add(element);
        }
    }
    private static void Task1()
    {
        Console.WriteLine($"1. Task: Number of elements in list: {elements.Count}");
    }
}
class Element
{
    public string? Year { get; set; }
    public string? Name { get; set; }
    public string? Symbol { get; set; }
    public int AtomicNumber { get; set; }
    public string? Chemist { get; set; }
    public Element(string lines)
    {
        string[] sa = lines.Split(';');
        Year = sa[0];
        Name = sa[1];
        Symbol = sa[2];
        AtomicNumber = int.Parse(sa[3]);
        Chemist = sa[4];
    }
}