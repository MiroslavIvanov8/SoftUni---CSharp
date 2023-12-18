int intergerVal;
float floatingPointVal;
char charVal;
bool boolenaVal;
string stringVal;
string input;
while ((input = Console.ReadLine()) != "END")
{
    if (int.TryParse(input, out intergerVal))
        Console.WriteLine($"{input} is integer type");
    else if(float.TryParse(input, out floatingPointVal))
        Console.WriteLine($"{input} is floating point type");
    else if(char.TryParse(input, out charVal))
        Console.WriteLine($"{input} is character type");
    else if(bool.TryParse(input, out boolenaVal))
        Console.WriteLine($"{input} is boolean type");
    else
        Console.WriteLine($"{input} is string type");    
}