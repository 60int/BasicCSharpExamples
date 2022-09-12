using System.IO;

class Program
{
    static readonly List<Expression> expressions = new();
    static void Main()
    {
        ReadCSV();
    }
    private static void ReadCSV()
    {
        using StreamReader reader = new("expressions.txt");
        while (!reader.EndOfStream)
        {
            expressions.Add(new Expression(reader.ReadLine()));
        }
        reader.Close();
    }
    private static void Task1()
    {
        Console.WriteLine($"1. Task: {expressions.Count}");
    }
    private static void Task2()
    {
        Console.WriteLine($"2. Task: {expressions.Count(a => a.Operator == "mod")}");
    }
    private static void Task3()
    {
        Console.WriteLine($"3. Task: {(expressions.FirstOrDefault(a => a.FirstOperand % 10 == 0 && a.SecondOperand % 10 == 0) != null ? "There aren't any" : "There are")}");
    }
    private static void Task4()
    {
        Console.WriteLine("4. Task: ");
        Console.WriteLine($"\tmod -> {expressions.Count(o => o.Operator == "mod")}");
        Console.WriteLine($"\t/ -> {expressions.Count(o => o.Operator == "/")}");
        Console.WriteLine($"\tdiv -> {expressions.Count(o => o.Operator == "div")}");
        Console.WriteLine($"\t- -> {expressions.Count(o => o.Operator == "-")}");
        Console.WriteLine($"\t* -> {expressions.Count(o => o.Operator == "*")}");
        Console.WriteLine($"\t+ -> {expressions.Count(o => o.Operator == "+")}");
    }
}
class Expression
{
    public int FirstOperand { get; set; }
    public string? Operator { get; set; }
    public int SecondOperand { get; set; }
    public Expression(string line)
    {
        string[] parts = line.Split(' ');
        FirstOperand = int.Parse(parts[0]);
        Operator = parts[1];
        SecondOperand = int.Parse(parts[2]);
    }
}