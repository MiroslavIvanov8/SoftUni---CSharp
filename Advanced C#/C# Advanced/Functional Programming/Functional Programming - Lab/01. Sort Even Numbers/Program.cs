namespace _01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sorted = Console.ReadLine()
                .Split(", ")
                .Select(n=> int.Parse(n))
                .Where((int n)=>
                {
                    return n % 2 == 0;
                })
                .OrderBy(n=>n)
                .ToArray();

            Console.WriteLine(string.Join(", ",sorted));
        }
    }
}