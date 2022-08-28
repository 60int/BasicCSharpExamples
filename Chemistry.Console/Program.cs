using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Text.RegularExpressions;

class Program
{
    //First task
    //Create class for Data and read chemistry.csv file
    //Display the number of elements in file

    //Second task
    //

    static readonly List<Element> elements = new();

    static void Main()
    {
        ReadCSV();
        Task1();
        Task2();
        string Symbol = Task3();
        Task4(Symbol);
        Task5();
        Task6();
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
    private static void Task2()
    {
        Console.WriteLine($"2. Task: {elements.Count(a => a.Year!.Contains("Ancient"))}");
    }
    private static string Task3()
    {
        string pattern = @"^[a-zA-Z]+$";
        Regex regex = new(pattern);
        Match match;
        string symbol;
        Console.Write("5. Task: Write a checmical symbol: ");
        string? v = Console.ReadLine();
        symbol = v!;
        do
        {
            match = regex.Match(symbol);
        } while (!(symbol.Length == 1 || symbol.Length == 2) && match.Success);
        return symbol;
    }
    private static void Task4(string symbol)
    {
        Console.WriteLine("4. Task: Search: ");
        bool symbolIsTrue = false;
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].Symbol?.ToUpper() == symbol.ToUpper())
            {
                symbolIsTrue = true;
                Console.WriteLine($"\tThe symbol of element: {elements[i].Symbol}");
                Console.WriteLine($"\tThe name of element: {elements[i].Name}");
                Console.WriteLine($"\tThe number of element: {elements[i].AtomicNumber}");
                Console.WriteLine($"\tThe year of discovery: {elements[i].Year}");
                Console.WriteLine($"\tThe chemists name: {elements[i].Chemist}");
            }
        }
        if (symbolIsTrue == false)
        {
            Console.WriteLine("Symbol doesn't exist");
        }
    }
    private static void Task5()
    {
        int longest = 0;
        for (int i = 0; i < elements.Count - 1; i++)
        {
            if (elements[i].Year != "Ancient")
            {
                if (int.Parse(elements[i + 1].Year) - int.Parse(elements[i].Year)> longest)
                {
                    longest = int.Parse(elements[i + 1].Year) - int.Parse(elements[i].Year);
                }
            }
        }
        Console.WriteLine($"5. Task: The longest year between two discoveries was {longest}.");
    }
    private static void Task6()
    {
        Console.WriteLine("8. Task: Statistics: ");
        elements.GroupBy(j => j.Year).Where(g => g.Count() > 3 && g.Key != "Ancient").ToList().ForEach(a => Console.WriteLine($"\t{a.Key}: {a.Count()} pieces."));
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