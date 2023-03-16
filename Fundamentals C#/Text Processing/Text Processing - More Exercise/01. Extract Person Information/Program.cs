namespace _01._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> names= new Dictionary<string,string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split('|','*');
                string name = ReturnName(input);
                string age = ReturnAge(input);
                bool reversed = false;
                if (int.TryParse(name, out int number))
                {
                    string token = age;
                    age = name;
                    name = token;
                    
                }
                
                names.Add(name,age);
            }
            foreach (var name in names)
            {
                Console.WriteLine($"{name.Key} is {name.Value} years old.");
            }
        }
        static string ReturnName(string[] input)
        {
            string[] nameInfo = input[0].Split(" ");
            string name = nameInfo[nameInfo.Length - 1];
            name = name.Remove(0, 1);
            return name;
        }
        static string ReturnAge(string[] input)
        {
            string[] ageInfo = input[1].Split(" ");
            string age = ageInfo[ageInfo.Length - 1];
            age = age.Remove(0, 1);
            return age;
        }
    }
}