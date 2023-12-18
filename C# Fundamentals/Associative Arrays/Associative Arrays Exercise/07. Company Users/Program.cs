using System.Runtime.CompilerServices;

namespace _07._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string,List<string>> Company = new Dictionary<string,List<string>>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string company = info[0];
                string id = info[1];
                if (!Company.ContainsKey(company))
                {
                    Company.Add(company, new List<string>());
                    
                }
                List<string> currentList = Company[company];
                if (currentList.Contains(id))
                {
                    continue;
                }
                else
                    currentList.Add(id);
            }

            foreach (var company in Company)
            {
                Console.WriteLine(company.Key);
                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}