using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

class Program
{
    static readonly List<Pilot> pilots = new();
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
        foreach (var item in File.ReadAllLines("pilots.csv", Encoding.UTF8).Skip(1))
        {
            Pilot pilot = new(item);
            pilots.Add(pilot);
        }
    }
    private static void Task1()
    {
        Console.WriteLine($"1. Task: {pilots.Count}");
    }
    private static void Task2()
    {
        Console.WriteLine($"2. Task: {pilots.Last().Name}");
    }
    private static void Task3()
    {
        Console.WriteLine("3. Task: ");
        pilots.Where(a => a.DateOfBirth < DateTime.Parse("1901.01.01")).ToList().ForEach(x => Console.WriteLine($"\t{x.Name} ({x.DateOfBirth.ToShortDateString()})"));
    }
    private static void Task4()
    {
        Console.WriteLine($"4. Task: {pilots.FindAll(b => b.StartNumber > 0).OrderBy(a => a.StartNumber).First().Nationality}");
    }
    private static void Task5()
    {
        Console.WriteLine("5. Task: ");
        pilots.GroupBy(a => a.StartNumber).Where(g => g.Count() > 1 && g.Key != 0).ToList().ForEach(a => Console.Write(a.Key + ", "));
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