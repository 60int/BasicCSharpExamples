using System.Text;

class Program
{
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
        Console.WriteLine($"1. Task: {dataList.Count()}");
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
    public Data(string line)
    {
        string[] la = line.Split(';');
        Year = int.Parse(la[0]);
        Month = int.Parse(la[1]);
        FloorArea = int.Parse(la[2]);
        Settlement = la[3];
        ComfortLevel = la[4];
        Taxes = int.Parse(la[5]);
    }
    public string ToHTML()
    {
        return $"<tr><td>{Year}</td><td>{Month}</td><td>{FloorArea}</td><td>{Settlement}</td><td>{ComfortLevel}</td><td>{Taxes}</td></tr>";
    }
}