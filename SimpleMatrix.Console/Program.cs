class Program
{
    public static Random rnd = new();
    static int[,] CreateRandomMatrix(int line, int column)
    {
        int[,] matrix_function = new int[line, column];
        for (int i = 0; i < line; i++)
        {
            for (int j = 0; j < column; j++)
            {
                matrix_function[i, j] = rnd.Next(1, 20); 
            }
        }
        return matrix_function;
    }
    static void ExportMatrix(int[,] ints)
    {
        for (int i = 0; i < ints.GetLength(0); i++)
        {
            for (int j = 0; j < ints.GetLength(1); j++)
            {
                Console.Write("{0}\t", ints[i,j]);
            }
            Console.WriteLine();
        }
    }
    static void Main()
    {
        int[,] matrix = new int[5, 10];

        //Update
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                matrix[i, j] = rnd.Next(1, 20);
            }
        }
        //Export
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write("{0}\t", matrix[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("This is a matrix function");
        int[,] newMatrix = CreateRandomMatrix(4, 5);
        ExportMatrix(newMatrix);
        Console.ReadLine();
    }
}