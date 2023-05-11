namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var dictionary = new Dictionary<double, int>();
            foreach (double number in arr)
            {
                if (dictionary.ContainsKey(number))
                {
                    dictionary[number]++;
                }
                else
                    dictionary[number] = 1;
            }
            foreach (var number in dictionary)
            {
                Console.WriteLine($"{ number.Key} - {number.Value} times");
            }    
        }
    }
}