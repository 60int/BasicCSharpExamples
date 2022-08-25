using System.Text;

class Program
{
    //First task
    //Create class for Data and read taxes.csv file
    //Display how many tax returns were made this year

    //Second task
    //Ask the user for a month (number from 1 to 12) and count how much
    //money came in from tax returns in that month

    //Thirds task
    //Search for which month had the biggest revenue in the second year

    //Fourth task
    //Create a basic HTML page where you display all the tax returns in a table

    static readonly List<Data> dataList = new();
    static void Main()
    {
        ReadCSV();
        FirstTask();
        SecondTask();
        ThirdTask();
        FourtTask();
    }
    private static void ReadCSV()
    {
        foreach (var item in File.ReadAllLines("taxes.csv", Encoding.UTF8).Skip(1))
        {
            Data data = new(item);
            dataList.Add(data);
        }
    }
    private static void FirstTask()
    {
        Console.WriteLine($"1. Task: {dataList.Count}");
    }
    private static void SecondTask()
    {
        Console.WriteLine("2. Task: Enter a month: ");
        int month = int.Parse(Console.ReadLine());
        if (month < 1 || month > 12)
        {
            Console.WriteLine("2. Task: This month doesn't exist.");
        }
        else
        {
            int sum = 0;
            foreach (Data item in dataList)
            {
                if (item.Month == month)
                {
                    sum += item.Taxes;
                }
            }
            Console.WriteLine($"2. Task: {month}. month's income: {sum} USD");
        }
    }
    private static void ThirdTask()
    {
        Console.WriteLine($"3. Task: Highest tax revenue for a single property was in the " +
            $"{dataList.Where(a => a.Year == 2).OrderByDescending(x => x.Taxes).First().Month}. month.");
    }
    private static void FourtTask()
    {
        using StreamWriter writer = new("taxes2.html", false, Encoding.UTF8);
        writer.Write("<table>");
        foreach (Data item in dataList)
        {
            writer.Write(item.ToHTML());
        }
        writer.WriteLine("</table>");
        Console.WriteLine("4. Task: taxes2.html");
    }
}
class Data
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int FloorArea { get; set; }
    public string Settlement { get; set; }
    public string ComfortLevel { get; set; }
    public int Taxes { get; set; }
    public Data(string lines)
    {
        string[] parts = lines.Split(';');
        Year = int.Parse(parts[0]);
        Month = int.Parse(parts[1]);
        FloorArea = int.Parse(parts[2]);
        Settlement = parts[3];
        ComfortLevel = parts[4];
        Taxes = int.Parse(parts[5]);
    }
    public string ToHTML()
    {
        return $"<tr><td>{Year}</td><td>{Month}</td><td>{FloorArea}</td><td>{Settlement}</td><td>{ComfortLevel}</td><td>{Taxes}</td></tr>";
    }
}