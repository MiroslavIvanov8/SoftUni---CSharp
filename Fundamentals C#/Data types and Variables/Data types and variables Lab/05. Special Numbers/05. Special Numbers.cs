








int numbers = int.Parse(Console.ReadLine());
int specialNum = 0;
int cnt = 0;
for (int i = 1; i <= numbers; i++)
{
    specialNum = i;
    cnt++;
    int sum = 0;
    while (specialNum>0)
    {
        sum += specialNum % 10;
        specialNum/= 10;
    }
    if (sum == 5 || sum == 7 || sum == 11)
    {
        Console.WriteLine($"{cnt} -> True");
        
    }
    else
    {
        Console.WriteLine($"{cnt} -> False");
        
    }
}   