using System.Text;
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
        int ancientCount = elements.Count(a => a.Year!.Contains("Ancient"));
        Console.WriteLine($"2. Task: Number of elements discovered in ancient times: {ancientCount}");
    }
    private static string Task3()
    {
        Console.Write("5. Task: Write a chemical symbol: ");
        string symbol = Console.ReadLine();
        while (symbol.Length < 1 || symbol.Length > 2 || !symbol.All(char.IsLetter))
        {
        Console.Write("Invalid input. Please enter a chemical symbol with 1 or 2 letters: ");
        symbol = Console.ReadLine();
        }
        return symbol;
    }
    private static void Task4(string symbol)
    {
        Console.WriteLine("4. Task: Search: ");
        Element element = elements.FirstOrDefault(e => e.Symbol?.Equals(symbol, StringComparison.OrdinalIgnoreCase) == true);
        if (element != null)
        {
            Console.WriteLine($"\tSymbol of the element: {element.Symbol}");
            Console.WriteLine($"\tName of the element: {element.Name}");
            Console.WriteLine($"\tAtomic number of the element: {element.AtomicNumber}");
            Console.WriteLine($"\tYear of discovery: {element.Year}");
            Console.WriteLine($"\tThe chemist's name: {element.Chemist}");
        }
        else
        {
            Console.WriteLine("Symbol doesn't exist");
        }
    }
    private static void Task5()
    {
        int[] years = elements.Where(e => e.Year != "Ancient").Select(e => int.Parse(e.Year)).OrderBy(y => y).ToArray();
        int longest = Enumerable.Range(0, years.Length - 1).Max(i => years[i + 1] - years[i]);
        Console.WriteLine($"5. Task: The longest year between two discoveries was {longest}.");
    }
    private static void Task6()
    {
        Console.WriteLine("8. Task: Years with three or more discoveries: ");
        var groups = elements.GroupBy(j => j.Year).Where(g => g.Count() > 3 && g.Key != "Ancient");
        foreach (var group in groups)
        {
            Console.WriteLine($"\t{group.Key}: {group.Count()} discoveries.");
        }
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
