int lines = int.Parse(Console.ReadLine());
int openingBrackets = 0;
int closingBrackets = 0;
for (int i = 0; i < lines; i++)
{
    string line = Console.ReadLine();
    if (line == "(")
    {
        openingBrackets++;
        if (openingBrackets - closingBrackets == 2)
        {
            Console.WriteLine("UNBALANCED");
            return;
        }
    }
    if (line == ")")
    {
        closingBrackets++;
        if (openingBrackets - closingBrackets != 0)
        {
            Console.WriteLine("UNBALANCED");
            return;
        }
    }
}
if (openingBrackets != closingBrackets)
    Console.WriteLine("UNBALANCED");
else
    Console.WriteLine("BALANCED");
    

    