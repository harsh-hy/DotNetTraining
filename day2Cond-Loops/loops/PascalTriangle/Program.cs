using System;

class PascalsTriangle
{
    static void Main()
    {
        Console.Write("Enter number of rows: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            for (int space = 0; space < n - i; space++)
                Console.Write(" ");

            int val = 1; 
            for (int j = 0; j <= i; j++)
            {
                Console.Write(val + " ");
                val = val * (i - j) / (j + 1);
            }
            Console.WriteLine();
        }
    }
}