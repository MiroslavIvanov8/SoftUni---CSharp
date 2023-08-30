string command = Console.ReadLine();
int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());

Calculation(command,number1,number2);
static void Calculation(string command ,int num1 ,int num2)
{
     int result = 0;
    if (command == "add")
    { 
        result = num1 + num2;
        Console.WriteLine(result);
    }
    if (command == "multiply")
    {
        result = num1 * num2;
        Console.WriteLine(result);
    }
    if (command == "subtract")
    {
        result = num1 - num2;
        Console.WriteLine(result);
    }
    if (command == "divide")
    {
        result = num1 / num2;
        Console.WriteLine(result);
    }
}