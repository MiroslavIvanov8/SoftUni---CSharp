namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = string.Empty;

           

            Func<string,List<int>, List<int>> maniplulate = (command, numbers) =>
            {
                List<int> manimulatedList = new ();

                if (command == "multiply")
                {
                    foreach (int currNumber in numbers)
                    {
                        manimulatedList.Add(currNumber * 2);
                    }
                }

                else if (command == "add")
                {
                    foreach (int currNumber in numbers)
                    {
                        manimulatedList.Add(currNumber + 1);
                    }
                }
                else if (command == "subtract")
                {
                    foreach (int currNumber in numbers)
                    {
                        manimulatedList.Add(currNumber - 1);
                    }
                }
                return manimulatedList;
            };
            
            Action<List<int>> print = numbers =>
            {
                Console.WriteLine(string.Join(" ", numbers));
            };

            while (true)
            {
                command = Console.ReadLine();

                switch (command)
                {
                    case "end":
                        return;
                    case "add":
                        numbers = maniplulate(command,numbers);
                        continue;
                    case "multiply":
                        numbers = maniplulate(command,numbers);
                        continue;
                    case "subtract":
                         numbers = maniplulate(command, numbers);
                        continue;
                    case "print":
                        print(numbers);
                        continue;
                }
                
            }
        }
    }
}