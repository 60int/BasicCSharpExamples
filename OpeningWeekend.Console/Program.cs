using System.IO;
using System.Text;
using System.Threading.Tasks.Dataflow;
using System.Transactions;

class Program
{
    static readonly List<Film> films = new();
    static void Main()
    {
        ReadCSV();
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
    }
    private static void ReadCSV()
    {
        foreach (var item in File.ReadAllLines("openingweekend.txt", Encoding.UTF8).Skip(1))
        {
            Film film = new(item);
            films.Add(film);
        }
    }
    private static void Task1()
    {
        Console.WriteLine($"1. Task: Number of movies in file: {films.Count}");
    }
    private static void Task2()
    {
        Console.WriteLine($"2. Task: UIP Duna Publisher boxoffice 1. week: {films.Where(x => x.Publisher == "UIP").OrderBy(p => p.Premiere).Select(y => y.Income).Sum()} HUF");
    }
    private static void Task3()
    {
        Console.WriteLine("3. Task: Highest viewer count ever in first week: ");
        Console.WriteLine($"\tOriginal Title: {films.OrderByDescending(a => a.Viewers).First().OriginalTitle}");
        Console.WriteLine($"\tHungarianTitle: {films.OrderByDescending(a => a.Viewers).First().HungarianTitle}");
        Console.WriteLine($"\tPublisher: {films.OrderByDescending(a => a.Viewers).First().Publisher}");
        Console.WriteLine($"\tBoxoffice: {films.OrderByDescending(a => a.Viewers).First().Income} HUF");
        Console.WriteLine($"\tViews: {films.OrderByDescending(a => a.Viewers).First().Viewers} people");
    }
    private static void Task4()
    {
        Console.WriteLine($"4. Task: {(films.All(a => a.OriginalTitle.StartsWith("W") && a.HungarianTitle.StartsWith("W")) ? "Theres was a movie like that" : "There wasn't a movie like that")}");
    }
    private static void Task5()
    {
        using StreamWriter writer = new("stats.csv");
        writer.WriteLine("UIP" + ";" + films.Where(x => x.Publisher == "UIP").Count());
        writer.WriteLine("Forum" + ";" + films.Where(x => x.Publisher == "Forum").Count());
        writer.WriteLine("InterCom" + ";" + films.Where(x => x.Publisher == "InterCom").Count());
        writer.WriteLine("Szinfolt Film" + ";" + films.Where(x => x.Publisher == "Szinfolt Film").Count());
        writer.WriteLine("Bid Bang Media" + ";" + films.Where(x => x.Publisher == "Bid Bang Media").Count());
        writer.WriteLine("MoziNet" + ";" + films.Where(x => x.Publisher == "MoziNet").Count());
        writer.WriteLine("Vertigo" + ";" + films.Where(x => x.Publisher == "Vertigo").Count());
        writer.WriteLine("Freeman" + ";" + films.Where(x => x.Publisher == "Freeman").Count());
        writer.WriteLine("ADS" + ";" + films.Where(x => x.Publisher == "ADS").Count());
        writer.Close();
    }
    private static void Task6()
    {
        int longest = 0;
        for (int i = 0; i < films.Count - 1; i++)
        {
            if (films[i].Publisher == "InterCom")
            {
                if (int.Parse((films[i + 1].Premiere.Day).ToString()) - int.Parse((films[i].Premiere.Day).ToString()) > longest)
                {
                    longest = int.Parse((films[i + 1].Premiere.Day).ToString()) - int.Parse((films[i].Premiere.Day).ToString());
                }
            }
        }
        Console.WriteLine($"6. Task: The longest period between two InterCom releases: {longest} days");
    }
}
class Film
{
    public string? OriginalTitle { get; set; }
    public string? HungarianTitle { get; set; }
    public DateTime Premiere { get; set; }
    public string? Publisher { get; set; }
    public long Income { get; set; }
    public int Viewers { get; set; }
    public Film(string lines)
    {
        string[] sa = lines.Split(';');
        OriginalTitle = sa[0];
        HungarianTitle = sa[1];
        Premiere = DateTime.Parse(sa[2]);
        Publisher = sa[3];
        Income = long.Parse(sa[4]);
        Viewers = int.Parse(sa[5]);
    }
}