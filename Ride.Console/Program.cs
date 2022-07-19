using Ride.Console.Properties;

class Program
{
    //Task 1
    //Read CSV file

    static readonly List<Taxi> taxis = new();
    static void Main()
    {
        ReadCSV();
    }
    private static void ReadCSV()
    {
        Resources.taxis.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Skip(1).ToList().ForEach(a => taxis.Add(new Taxi(a)));
    }
}
class Taxi
{
    public int Taxi_Id { get; set; }
    public DateTime Departure { get; set; }
    public int TravelTime { get; set; }
    public double Distance { get; set; }
    public double Fare { get; set; }
    public double Tip { get; set; }
    public string? PayType { get; set; }
    public Taxi(string lines)
    {
        string[] parts = lines.Split(';');
        Taxi_Id = int.Parse(parts[0]);
        Departure = DateTime.Parse(parts[1]);
        TravelTime = int.Parse(parts[2]);
        Distance = double.Parse(parts[3]);
        Fare = double.Parse(parts[4]);
        Tip = double.Parse(parts[5]);
        PayType = parts[6];
    }
}