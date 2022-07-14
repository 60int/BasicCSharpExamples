using System.Text;

class Program
{
    static readonly List<Data> dataList = new();
    static void Main(string[] args)
    {
        ReadCSV();
    }
    private static void ReadCSV()
    {
        foreach (var item in File.ReadAllLines("taxes.csv", Encoding.UTF8).Skip(1))
        {
            Data data = new(item);
            dataList.Add(data);
        }
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