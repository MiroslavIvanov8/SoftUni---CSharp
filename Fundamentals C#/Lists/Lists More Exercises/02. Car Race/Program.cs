namespace _02._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(float.Parse)
                .ToArray();

            float leftRacerTime = 0;
            float rightRacerTime = 0;
            for (int i = 0; i < arr.Length / 2; i++)
            {
                leftRacerTime += arr[i];
                if (arr[i] == 0)
                    leftRacerTime *= 0.80F;
            }
            for (int i = arr.Length-1; i > arr.Length / 2; i--)
            {
                rightRacerTime += arr[i];
                if (arr[i] == 0)
                    rightRacerTime *= 0.80F;         
            }
            if (leftRacerTime < rightRacerTime)
                Console.WriteLine($"The winner is left with total time: {leftRacerTime}");
            else
                Console.WriteLine($"The winner is right with total time: {rightRacerTime}");
        }
    }
}