namespace _10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // fiel size
            int[] field = new int [n];
            int[] ladybugs = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            // Spawning Ladybugs on the field
            for(int i = 0;i< ladybugs.Length;i++)
            {
                if (ladybugs[i] >=0 && ladybugs[i]<= field.Length)
                field[ladybugs[i]] = 1;
            }

            // Game Starts
            string command;
            while((command = Console.ReadLine()) != "end")
            {                
                string []cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .ToArray();
                int ladyBugsIndex = int.Parse(cmdArgs[0]);
                string direction = cmdArgs[1];
                int flyLength = int.Parse(cmdArgs[2]); 

                //check if ladybugindex is valid
                if (ladyBugsIndex < 0 && ladyBugsIndex > field.Length)
                {
                    // Invalid Index
                    continue;
                }
                if (field[ladyBugsIndex] == 0)
                {
                    // no Ladybug at this index
                    continue;
                }
                // ladybug starts flying
                //--right ladybugindex + flylength
                //--left ladybugindex -flylength
                // ladybug starts flying field[ladybugindex]=0;
                field[ladyBugsIndex] = 0;
                if (direction == "left")
                {
                    flyLength *= -1;
                }
                int nextIndex = ladyBugsIndex + flyLength;
                
                while (nextIndex >= 0 && nextIndex < field.Length && field[nextIndex]==1)
                {
                    nextIndex += flyLength;
                }
                

                // Two possibilities
                if (nextIndex<0 || nextIndex>field.Length)
                {
                    continue;
                }
                field[nextIndex] = 1;
                nextIndex = 0;
                

            }
            Console.WriteLine(string.Join(" ", field));
        } 
    }
}