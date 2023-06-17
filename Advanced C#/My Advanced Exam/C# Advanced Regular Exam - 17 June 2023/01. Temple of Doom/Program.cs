namespace _01._Temple_of_Doom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Stack<int> substances = new (Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            List<int> challenges = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (tools.Any() && substances.Any())
            { 
                int currTool = tools.Dequeue();
                int currSubstance = substances.Pop();
                int sum = currTool * currSubstance;

                if (challenges.Any(x => x == sum))
                {
                    challenges.Remove(sum);
                }
                else
                { 
                    tools.Enqueue(currTool+1);
                    currSubstance = currSubstance - 1;
                    if(currSubstance>0)
                        substances.Push(currSubstance);
                }
            }
            if (challenges.Any())
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }
            else
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            if(tools.Any())
                Console.WriteLine($"Tools: {string.Join(", ",tools)}");
            if(substances.Any())
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            if (challenges.Any())
            Console.WriteLine($"Challenges: {string.Join(", ",challenges)}");
        }
    }
}