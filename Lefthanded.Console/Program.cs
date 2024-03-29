﻿using Lefthanded.Console.Properties;

class Program
{
    //First task
    //Create class for players and read lefthanded.csv file
    //Display number of players on the console

    //Second task
    //Display the name and height of players who last played
    //on october 1999 in a list and only show one decimal number
    //for their height

    //Third task
    //Ask the user for a date (between 1990 and 1999)
    //if the user gave a wrong number display an error message

    //Fourth task
    //Display the sum of the previous players weight
    //Only display two decimal numbers and round the numbers

    static readonly List<Player> players = new();
    static void Main()
    {
        ReadCSV();
        FirstTask();
        SecondTask();
        Task3_4();
    }
    private static void ReadCSV()
    {
        Resources.lefthanded.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
            .Skip(1)
            .ToList()
            .ForEach(a => players.Add(new Player(a)));
    }
    private static void FirstTask()
    {
        Console.WriteLine($"1. Task: Number of players in file: {players.Count}");
    }
    private static void SecondTask()
    {
        Console.WriteLine("2. Task: ");
        players.FindAll(a => a.LatestDate < DateTime.Parse("1999.11") && a.LatestDate > DateTime.Parse("1999.10"))
            .ToList()
            .ForEach(x => Console.WriteLine($"\t{x.Name}, {Math.Round(x.Height * 2.54, 1)}"));
    }
    private static void Task3_4()
    {
        bool included = false;
        int input = 0;
        Console.WriteLine("3. Task: ");
        Console.WriteLine("Type a number between 1990 and 1999: ");
        while (included == false)
        {
            input = int.Parse(Console.ReadLine());
            if (input >= 1990 && input <= 1999)
            {
                included = true;
            }
            else
            {
                Console.WriteLine("Wrong number");
            }
        }
        double weightSum = 0;
        double piece = 0;
        for (int i = 0; i < players.Count; i++)
        {
            if (input >= players[i].FirstDate.Year && input <= players[i].LatestDate.Year)
            {
                weightSum += players[i].Weight;
                piece++;
            }
        }
        double sum = weightSum / piece;
        Console.WriteLine($"4. Task: {Math.Round(sum, 2)}");
    }
}
class Player
{
    public string Name { get; set; }
    public DateTime FirstDate { get; set; }
    public DateTime LatestDate { get; set; }
    public int Weight { get; set; }
    public double Height { get; set; }
    public Player(string lines)
    {
        string[] parts = lines.Split(';');
        Name = parts[0];
        FirstDate = DateTime.Parse(parts[1]);
        LatestDate = DateTime.Parse(parts[2]);
        Weight = int.Parse(parts[3]);
        Height = int.Parse(parts[4]);
    }
}