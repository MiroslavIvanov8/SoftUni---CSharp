
int number = int.Parse(Console.ReadLine());


    for (int i = 1; i <= number; i++)
    {
        PrintNumbers(i);
    }

    for (int i = number - 1; i >= 1; i--)
    {
        PrintNumbers(i);
    }


    static void PrintNumbers(int end)
    {
    
        for (int j = 1; j <= end; j++)
        {
        Console.Write(j + " ");
        }
         Console.WriteLine();
    }


