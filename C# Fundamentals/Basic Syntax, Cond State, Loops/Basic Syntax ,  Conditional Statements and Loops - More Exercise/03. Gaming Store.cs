double budget = double.Parse(Console.ReadLine());
string game =string.Empty;
double spendOnGames = 0;
while ((game = Console.ReadLine()) != "Game Time")
{
    if (budget == 0)
    {
        Console.WriteLine("Out of money!");
        break;
    }
    if (game != "OutFall 4" && game != "CS: OG" && game != "Zplinter Zell" && game != "Honored 2" && game != "RoverWatch" && game != "RoverWatch Origins Edition")
    {
        Console.WriteLine("Not Found");
    }       
    if (game == "Honored 2")
    {
        if (budget >= 59.99)
        {
            Console.WriteLine($"Bought {game}");
            spendOnGames += 59.99;
            budget -= 59.99;
            if (budget <= 0)
            {
                Console.WriteLine("Out of money!");
                break;
            }
        }
        else if (budget < 59.99)
            Console.WriteLine($"Too Expensive");
    }       
    if (game == "OutFall 4")
    {
         if (budget >= 39.99)
        {
            Console.WriteLine($"Bought {game}");
            spendOnGames += 39.99;
            budget -= 39.99;
            if (budget <= 0)
            {
                Console.WriteLine("Out of money!");
                break;
            }
        }

        else if (budget<39.99)
            Console.WriteLine($"Too Expensive");

    }
    if (game == "RoverWatch Origins Edition")
    { 
        if (budget >= 39.99)
        {
            Console.WriteLine($"Bought {game}");
            spendOnGames += 39.99;
            budget -= 39.99;
            if (budget <= 0)
            {
                Console.WriteLine("Out of money!");
                break;
            }
        }

        else if (budget < 39.99)
            Console.WriteLine($"Too Expensive");
    }

    if (game == "RoverWatch")
    {
        if (budget >= 29.99)
        {
            Console.WriteLine($"Bought {game}");
            spendOnGames += 29.99;
            budget -= 29.99;
            if (budget <= 0)
            {
                Console.WriteLine("Out of money!");
                break;
            }
        }

        else if (budget<29.99)
            Console.WriteLine($"Too Expensive");
    }

    if (game == "Zplinter Zell")
    {
        if (budget >= 19.99)
        {
            Console.WriteLine($"Bought {game}");
            spendOnGames += 19.99;
            budget -= 19.99;
            if (budget <= 0)
            {
                Console.WriteLine("Out of money!");
                break;
            }
        }

        else if(budget<19.99)
            Console.WriteLine($"Too Expensive");
    }

    if (game == "CS: OG")
    {
        if (budget >= 15.99)
        {
            Console.WriteLine($"Bought {game}");
            spendOnGames += 15.99;
            budget -= 15.99;
            if (budget <= 0)
            {
                Console.WriteLine("Out of money!");
                break;
            }
        }

        else if (budget < 15.99)
            Console.WriteLine($"Too Expensive");
    }
     
}
if(game== "Game Time")
{
    Console.WriteLine($"Total spent: ${spendOnGames:f2}. Remaining: ${budget:f2}");
}