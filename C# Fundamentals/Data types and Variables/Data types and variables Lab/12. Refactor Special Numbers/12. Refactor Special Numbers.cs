int numbers = int.Parse(Console.ReadLine());
int sum = 0;

bool isSpecialNumber = false;
for (int i = 1; i <= numbers; i++)
{
    
    int currentNum = i;
    while (i > 0)
    {
        sum += i % 10;
        i = i / 10;
    }
    if(isSpecialNumber = (sum == 5) || (sum == 7) || (sum == 11));
    {
        Console.WriteLine("{0} -> {1}", currentNum, isSpecialNumber);
    }
    sum = 0;
    i = currentNum;
}
