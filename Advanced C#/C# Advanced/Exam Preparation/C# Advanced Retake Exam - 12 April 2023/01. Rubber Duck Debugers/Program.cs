namespace _01._Rubber_Duck_Debugers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> programmersTime = new(
                Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

            Stack<int> tasksTime = new(
                Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());
            int t4 = 0;
            int t3 = 0;
            int t2 = 0;
            int t1 = 0;

            //10 15 12 18 22 6

            //12 16 5 6 9 1
            while (tasksTime.Any())
            {
                int currProgrammer = programmersTime.Peek();
                int currTask = tasksTime.Pop();
                int time = currProgrammer * currTask;
                if (time <= 60)
                {
                    t4++;
                    programmersTime.Dequeue();
                    
                }
                else if (time > 60 && time <= 120)
                {
                    t3++;
                    programmersTime.Dequeue();
                    
                }
                else if (time > 120 && time <= 180)
                {
                    t2++;
                    programmersTime.Dequeue();
                    
                }
                else if (time > 180 && time <=240)
                {
                    t1++;
                    programmersTime.Dequeue();
                }
                else if (time >240)
                {
                    programmersTime.Enqueue(programmersTime.Dequeue());
                    currTask = currTask - 2;
                    tasksTime.Push(currTask); 

                }                  
            }
            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {t4}");
            Console.WriteLine($"Thor Ducky: {t3}");
            Console.WriteLine($"Big Blue Rubber Ducky: {t2}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {t1}");
            

        }
    }
}
