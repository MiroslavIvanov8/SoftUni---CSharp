namespace _7._Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int desiredLength = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                ToList();

            //Predicate<string> isLenghtEnough = name =>
            //{
            //    if (name.Length <= desiredLength)
            //        return true;
            //    else
            //        return false;
            //};

            Action<List<string>, Predicate<string>> lengthCheck = (names, isLenghtEnough) =>
            {
                foreach (string name in names)
                {
                    if (isLenghtEnough(name))
                        Console.WriteLine(name);
                }
            };

            lengthCheck(names, n=>n.Length <=desiredLength);

        }
    }
}