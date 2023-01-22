int key = int.Parse(Console.ReadLine());
int lines = int.Parse(Console.ReadLine());

for (int i = 0; i < lines; i++)
{
    char symbol = char.Parse(Console.ReadLine());
    int letter = symbol + key;
    Console.Write($"{(char)letter}");
}
    
      
    

    


