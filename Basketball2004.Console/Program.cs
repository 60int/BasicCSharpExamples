using System.Text;
using System.Xml;

class Program
{
    //First task
    //Create a class for the Data and read results.csv file
    //Display the number of games played by Real Madrid in home team and in away on console

    static readonly List<Result> results = new();
    static void Main()
    {
        ReadCSV();
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
    }
    private static void ReadCSV()
    {
        foreach (var item in File.ReadAllLines("results.csv", Encoding.UTF8).Skip(1))
        {
            Result result = new(item);
            results.Add(result);
        }
    }
    private static void Task1()
    {
        Console.WriteLine($"1. Task: Real Madrid: Home {results.Count(a => a.HomeTeam!.Contains("Real Madrid"))}, Away: {results.Count(a => a.AwayTeam!.Contains("Real Madrid"))}");
    }
    private static void Task2()
    {
        Console.WriteLine($"2. Task: Was there a draw?: {(results.All(a => a.HomeScore == a.AwayScore) ? "Yes":"No")}");
    }
    private static void Task3()
    {
        Console.WriteLine($"3. Task: The team from Barcelona is called: {results?.Where(a => a.HomeTeam.Contains("Barcelona")).FirstOrDefault().HomeTeam}");
    }
    private static void Task4()
    {
        Console.WriteLine($"4. Task: ");
        results.Where(a => a.GameDate == DateTime.Parse("2004.11.21")).ToList().ForEach(x => Console.WriteLine($"\t{x.HomeTeam} - {x.AwayTeam} ({x.HomeScore}:{x.AwayScore})"));
    }
    private static void Task5()
    {
        Console.WriteLine("5. Task: ");
        results.GroupBy(a => a.Location).Where(y => y.Count() > 20).ToList().ForEach(x => Console.WriteLine($"\t{x.Key}: {x.Count()}"));
    }
}
class Result
{
    public string? HomeTeam { get; set; }
    public string? AwayTeam { get; set; }
    public int HomeScore { get; set; }
    public int AwayScore { get; set; }
    public string? Location { get; set; }
    public DateTime GameDate { get; set; }
    public Result(string lines)
    {
        string[] sa = lines.Split(';');
        HomeTeam = sa[0];
        AwayTeam = sa[1];
        HomeScore = int.Parse(sa[2]);
        AwayScore = int.Parse(sa[3]);
        Location = sa[4];
        GameDate = DateTime.Parse(sa[5]);
    }
}