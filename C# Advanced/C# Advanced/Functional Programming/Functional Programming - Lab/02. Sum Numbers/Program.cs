namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().
                Split(", ")
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(arr.Length);
            Console.WriteLine(arr.Sum());
        }
    }
}