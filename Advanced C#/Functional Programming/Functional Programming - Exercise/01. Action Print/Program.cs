namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> print = str => Console.WriteLine(string.Join(Environment.NewLine, str));
            
            print(names);
        }
        //static void Print(string[] names)
        //{
        //    foreach (string name in names)
        //        Console.WriteLine(name);
        //}
    }
    
}
    