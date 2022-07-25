using Ride.Console.Properties;

class Program
{
    //Task 1
    //Read CSV file, display all taxis

    //Task 2
    //Display the fare of taxi with id number 6185

    //Task 3
    //Display number of payments of payment types in a list

    static readonly List<Taxi> taxis = new();
    static void Main()
    {
        ReadCSV();
        Task1();
        Task2();
        Task3();
    }
    private static void ReadCSV()
    {
        Resources.taxis.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Skip(1).ToList().ForEach(a => taxis.Add(new Taxi(a)));
    }
    private static void Task1()
    {
        Console.WriteLine($"1. Task: {taxis.Count}");
    }
    private static void Task2()
    {
        Console.WriteLine($"2. Task: {taxis.Count(a => a.Taxi_Id == 6185)} rides made: {taxis.Where(a => a.Taxi_Id == 6185).Sum(x => x.Fare)}");
    }
    private static void Task3()
    {
        Console.WriteLine("3. Task: ");
        taxis.GroupBy(a => a.PayType).ToList().ForEach(x => Console.WriteLine($"\t{x.Key}: {x.Count()}"));
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