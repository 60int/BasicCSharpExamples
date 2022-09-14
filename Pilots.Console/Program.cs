using System.Text;

class Program
{
    static readonly List<Pilot> pilots = new();
    static void Main()
    {
        ReadCSV();
    }
    private static void ReadCSV()
    {
        foreach (var item in File.ReadAllLines("pilots.csv", Encoding.UTF8).Skip(1))
        {
            Pilot pilot = new(item);
            pilots.Add(pilot);
        }
    }
}
class Pilot
{
    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Nationality { get; set; }
    public int StartNumber { get; set; }
    public Pilot(string line)
    {
        string[] sa = line.Split(';');
        Name = sa[0];
        DateOfBirth = DateTime.Parse(sa[1]);
        Nationality = sa[2];
        if (!string.IsNullOrEmpty(sa[3]))
        {
            StartNumber = int.Parse(sa[3]);
        }
    }
}