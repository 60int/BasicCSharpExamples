using System.Text;

class Program
{
    static readonly List<Film> films = new();
    static void Main()
    {
        ReadCSV();
    }
    private static void ReadCSV()
    {
        foreach (var item in File.ReadAllLines("openingweekend.txt", Encoding.UTF8).Skip(1))
        {
            Film film = new(item);
            films.Add(film);
        }
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