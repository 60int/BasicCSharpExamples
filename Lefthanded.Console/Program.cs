using Lefthanded.Console.Properties;

class Program
{
    static readonly List<Player> players = new();
    static void Main()
    {
        ReadCSV();
    }
    private static void ReadCSV()
    {
        Resources.lefthanded.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
            .Skip(1)
            .ToList()
            .ForEach(a => players.Add(new Player(a)));
    }
}
class Player
{
    public string Name { get; set; }
    public DateTime FirstDate { get; set; }
    public DateTime LatestDate { get; set; }
    public int Weight { get; set; }
    public double Height { get; set; }
    public Player(string line)
    {
        string[] parts = line.Split(';');
        Name = parts[0];
        FirstDate = DateTime.Parse(parts[1]);
        LatestDate = DateTime.Parse(parts[2]);
        Weight = int.Parse(parts[3]);
        Height = int.Parse(parts[4]);
    }
}