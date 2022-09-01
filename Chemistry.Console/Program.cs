using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Text.RegularExpressions;

class Program
{
    //First task
    //Create a class for the Data and read chemistry.csv file
    //Display the number of elements in the file on the console

    //Second task
    //Display the number of elements discovered in acient times

    //Third task
    //Ask the user for a symbol, continue the search until the symbol is at least
    //one or two characters long and contains characters from the english alphabet [A-Z, a-z]

    //Fourth task
    //Select the symbol from task 3 and display the information about that element.
    //The search shouldn't be case sensitive, and if the search fails
    //Write "Symbol doesn't exist" in the console
    
    //Fifth task
    //Search for and then display the longest period between two discoveries

    //Sixth task
    //Display the years where three or more discoveries occured

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
                Console.WriteLine($"\tSymbol of the element: {elements[i].Symbol}");
                Console.WriteLine($"\tName of the element: {elements[i].Name}");
                Console.WriteLine($"\tAtomic umber of the element: {elements[i].AtomicNumber}");
                Console.WriteLine($"\tYear of discovery: {elements[i].Year}");
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