using System.Text;

class Program
{
    static readonly List<Film> films = new();
    static void Main()
    {
        ReadCSV();
        Task1();
        Task2();
        Task3();
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