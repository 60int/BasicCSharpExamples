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