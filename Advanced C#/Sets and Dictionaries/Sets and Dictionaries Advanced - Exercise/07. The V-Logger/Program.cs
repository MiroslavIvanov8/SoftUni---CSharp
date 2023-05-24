using System.Xml.Schema;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggers = new();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vloggerName = commandArgs[0];
                if (commandArgs.Contains("joined"))
                {
                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        vloggers.Add(vloggerName, new Vlogger());
                    }
                    else
                        continue;
                } 
                else if (commandArgs.Contains("followed"))
                {
                    string accToFollow = commandArgs[2];
                    if (!vloggers.ContainsKey(vloggerName) || !vloggers.ContainsKey(accToFollow))
                    {
                        continue;
                    }
                    else if (vloggerName == accToFollow)
                    {
                        continue;
                    }
                    else if (vloggers[vloggerName].Following.Contains(accToFollow))
                    {
                        continue;
                    }
                    else if (!vloggers[vloggerName].Following.Contains(accToFollow))
                    {
                        vloggers[vloggerName].Following.Add(accToFollow);
                        vloggers[accToFollow].Followed.Add(vloggerName);
                    }
                    

                }
            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int n = 1;
            foreach (var vlogger in vloggers.OrderByDescending(x=>x.Value.Followed.Count).ThenBy(x=>x.Value.Following.Count))
            {
                Console.WriteLine($"{n}. {vlogger.Key} : {vlogger.Value.Followed.Count} followers, {vlogger.Value.Following.Count} following");
                if (n == 1)
                {
                    foreach (string follower in vlogger.Value.Followed.OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                n++;
            }
        }
    }
    public class Vlogger
    {
          public List<string> Following = new();
         
          public List<string> Followed = new();
    }


}