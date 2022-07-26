using Ride.Console.Properties;

class Program
{
    //Task 1
    //Read CSV file, display all taxis

    //Task 2
    //Display the fare of taxi with id number 6185

    //Task 3
    //Display number of payments of payment types in a list

    //Task 4
    //Count and display the sum of distance the taxis have done, only display
    //two decimal numbers

    static readonly List<Taxi> taxis = new();
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
    private static void Task4()
    {
        Console.WriteLine($"4. Task: {Math.Round(taxis.Sum(a => a.Distance * 1.6),2)} km");
    }
    private static void Task5()
    {
        Console.WriteLine("7. Task: Longest ride: ");
        Console.WriteLine($"\tTravel time: {taxis.OrderBy(a => a.TravelTime).Last().TravelTime} seconds");
        Console.WriteLine($"\tID of driver: {taxis.OrderBy(a => a.TravelTime).Last().Taxi_Id}");
        Console.WriteLine($"\tDistance: {taxis.OrderBy(a => a.TravelTime).Last().Distance} km");
        Console.WriteLine($"\tFare: {taxis.OrderBy(a => a.TravelTime).Last().Fare} $");
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