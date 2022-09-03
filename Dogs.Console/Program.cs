using System.Data;
using System.Globalization;
using System.IO;
using System.Text;

class Program
{
    static readonly List<DogBreeds> dogBreeds = new();
    static readonly List<DogNames> dogNames = new();
    static readonly List<Dogs> dogs = new();
    static void Main()
    {
        ReadCSVs();
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
    }
    private static void ReadCSVs()
    {
        foreach (var item in File.ReadAllLines("DogBreeds.csv",Encoding.UTF8).Skip(1))
        {
            DogBreeds dog = new(item);
            dogBreeds.Add(dog);
        }
        foreach (var item in File.ReadAllLines("DogNames.csv", Encoding.UTF8).Skip(1))
        {
            DogNames dog = new(item);
            dogNames.Add(dog);
        }
        foreach (var item in File.ReadAllLines("Dogs.csv", Encoding.UTF8).Skip(1))
        {
            Dogs dog = new(item);
            dogs.Add(dog);
        }
    }
    private static void Task1()
    {
        Console.WriteLine($"1. Task: Number of dog names available: {dogNames.Count}");
    }
    private static void Task2()
    {
        Console.WriteLine($"2. Task: Average age of dogs: {Math.Round(dogs.Average(a => a.Age), 2)}");
    }
    private static void Task3()
    {
        var dog = dogs.OrderByDescending(a => a.Age).First();
        Console.WriteLine($"3. Task: The oldest dogs name and breed: " +
            $"{dogNames.Where(a => a.DogNameId == dog.NameId).FirstOrDefault().Name + ", " + dogBreeds.Where(x => x.Id == dog.BreedId).FirstOrDefault().Name}");
    }
    private static void Task4()
    {
        Dictionary<string, int> breeds = new();
        foreach (Dogs dog in dogs)
        {
            if (dog.LastExam == DateTime.Parse("2018.01.10"))
            {
                string key = dogBreeds.Single(a => a.Id == dog!.BreedId).Name!;
                if (breeds.ContainsKey(key))
                {
                    breeds[key]++;
                }
                else
                {
                    breeds.Add(key, 1);
                }
            }
        }
        Console.WriteLine("4. Task: Dog breeds examined on January 10th");
        foreach (var item in breeds)
        {
            Console.WriteLine($"\t{item.Key}: {item.Value} dog(s)");
        }
    }
    private static void Task5()
    {
        Dictionary<string, int> days = new();
        foreach (Dogs dog in dogs)
        {
            string key = dog.LastExam.ToString("yyyy-MM-dd");
            if (days.ContainsKey(key))
            {
                days[key]++;
            }
            else
            {
                days.Add(key, 1);
            }
        }
        Console.WriteLine($"5. Task: Busiest day so far: {days.FirstOrDefault(x => x.Value == days.Values.Max()).Key + ": " + days.Values.Max()} dogs");
    }
    private static void Task6()
    {
        using StreamWriter writer = new("NameStatistics.txt", false, Encoding.UTF8);
        Dictionary<string, int> names = new();
        foreach (Dogs dog in dogs)
        {
            string key = dogNames.Single(a => a.DogNameId == dog!.NameId).Name!;
            if (names.ContainsKey(key))
            {
                names[key]++;
            }
            else
            {
                names.Add(key, 1);
            }
        }
        var sortedNames = from entry in names orderby entry.Value descending select entry;
        foreach (var item in sortedNames)
        {
            writer.WriteLine(item.Key + ";" + item.Value);
        }
        Console.WriteLine("6. Task: Dog statistics file generated");
    }
}
class DogBreeds
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? OriginalName { get; set; }
    public DogBreeds(string lines)
    {
        string[] sa = lines.Split(';');
        Id = int.Parse(sa[0]);
        Name = sa[1];
        OriginalName = sa[2];
    }
}
class DogNames
{
    public int DogNameId { get; set; }
    public string? Name { get; set; }
    public DogNames(string lines)
    {
        string[] sa = lines.Split(';');
        DogNameId = int.Parse(sa[0]);
        Name = sa[1];
    }
}
class Dogs
{
    public int CurrentDogId { get; set; }
    public int BreedId { get; set; }
    public int NameId { get; set; }
    public double Age { get; set; }
    public DateTime LastExam { get; set; }
    public Dogs(string lines)
    {
        string[] sa = lines.Split(';');
        CurrentDogId = int.Parse(sa[0]);
        BreedId = int.Parse(sa[1]);
        NameId = int.Parse(sa[2]);
        Age = double.Parse(sa[3]);
        LastExam = DateTime.Parse(sa[4]);
    }
}