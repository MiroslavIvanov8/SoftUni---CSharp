


int lines = int.Parse(Console.ReadLine());
long sum = 0;
for (int i = 1; i <= lines; i++)
{
    string[] values = Console.ReadLine().Split(' ');
    long firstNum = long.Parse(values[0]);
    long secondNum = long.Parse(values[1]);

    if (firstNum > secondNum)
    {
        while (firstNum > 0)
        {
            long digit = firstNum % 10;
            sum+= digit;
            firstNum/=10;         
        }  
    }
    else if (firstNum < secondNum)
    {
        while(secondNum > 0)
        {
           long digit = secondNum % 10;
            sum+= digit; 
            secondNum/=10;
        }
    }
    else 
    {
        while (secondNum > 0)
        {
            long digit = secondNum % 10;
            sum += digit;
            secondNum /= 10;
        }
    }
    Console.WriteLine(sum);
    sum= 0;
}
