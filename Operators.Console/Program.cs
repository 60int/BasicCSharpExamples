using System.Data.Common;
using System.IO;

class Program
{
    //First Task
    //Create class for expressions, read data from text file, display number of
    //expressions on the console

    //Second Task
    //The division operator is called mod, find and display every
    //expression for every division on the console

    //Third Task
    //Find all the occasions where both operands can be divided by 10
    //and display them on the console

    //Fourth Task
    //Create a statistic for every expression type, count every occasion
    //of them and display them on the console

    //Fifth Task
    //Create a method that returns a string with the type of operations.
    //The method needs to handle the operations from Task Four and in
    //case of a non-existent operation it should return with a "wrong operator" message.
    //In other cases where the operator can't return normally, return with "Unkown error" message

    //Sixth Task
    //Ask the user for an expression then display the correct answer using the function from
    //Task Five. Only stop the task when the user writes "end".

    //Seventh Task
    //Create a text file that contains every solution for the expression from "expressions.txt"

    static readonly List<Expression> expressions = new();
    static void Main()
    {
        ReadCSV();
        Task1();
        Task2();
        Task3();
        Task4();
        Task6();
        Task7();
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
    private static string Task5(string input)
    {
        if (input.Equals("end"))
        {
            return "end";
        }
        string[] sa = input.Split(' ');
        string data = sa[0] + " " + sa[1] + " " + sa[2];
        string output;
        try
        {
            switch (sa[1])
            {
                default:
                    return ($"{data} = Wrong operator");
                case "mod":
                    output = data + " = " + (int.Parse(sa[0]) % int.Parse(sa[2]));
                    break;
                case "div":
                    output = data + " = " + (int.Parse(sa[0]) / int.Parse(sa[2]));
                    break;
                case "/":
                    output = data + " = " + (int.Parse(sa[0]) / double.Parse(sa[2]));
                    break;
                case "-":
                    output = data + " = " + (int.Parse(sa[0]) - int.Parse(sa[2]));
                    break;
                case "*":
                    output = data + " = " + (int.Parse(sa[0]) * int.Parse(sa[2]));
                    break;
                case "+":
                    output = data + " = " + (int.Parse(sa[0]) + int.Parse(sa[2]));
                    break;
            }
        }
        catch (Exception)
        {
            return ($"{data} = Unknown error");
        }
        return output;
    }
    private static void Task6()
    {
        string input = "";
        while (!input.Equals("end"))
        {
            Console.WriteLine("6. Task: Please write an expression: ");
            string? v = Console.ReadLine();
            input = v!;
            if (Task5(input).Equals("end"))
            {
                input = Task5(input);
            }
            else
            {
                Console.WriteLine(Task5(input) + "\n");
            }
        }
    }
    private static void Task7()
    {
        using StreamWriter writer = new("results.txt");
        string input = "";
        foreach (Expression item in expressions)
        {
            input = item.FirstOperand + " " + item.Operator + " " + item.SecondOperand;
            writer.Write($"{Task5(input)} \n");
        }
        writer.Close();
        Console.WriteLine("7. Task: results.txt is done");
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