
int number = int.Parse(Console.ReadLine());
for (int i = 0; i < number; i++)
{
    for (int j = 0; j < number; j++)
    {
        for (int k = 0; k < number; k++)
        {
            int first =(char)('a' + i);
            int second = (char)('a' + j);
            int third =(char)('a'+ k);
            Console.WriteLine($"{(char)first}{(char)second}{(char)third}");
        }
    }
}

