using System.Text;

class Program
{
    static readonly List<Result> results = new();
    static void Main()
    {
        ReadCSV();
    }
    private static void ReadCSV()
    {
        foreach (var item in File.ReadAllLines("results.csv", Encoding.UTF8).Skip(1))
        {
            Result result = new(item);
            results.Add(result);
        }
    }
}
class Result
{
    public string? HomeTeam { get; set; }
    public string? ForeignTeam { get; set; }
    public int HomeScore { get; set; }
    public int ForeignScore { get; set; }
    public string? Location { get; set; }
    public DateTime GameDate { get; set; }
    public Result(string lines)
    {
        string[] sa = lines.Split(';');
        HomeTeam = sa[0];
        ForeignTeam = sa[1];
        HomeScore = int.Parse(sa[2]);
        ForeignScore = int.Parse(sa[3]);
        Location = sa[4];
        GameDate = DateTime.Parse(sa[5]);
    }
}