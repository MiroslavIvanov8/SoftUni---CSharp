namespace BorderControl;
using System.Diagnostics.Metrics;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> list = new List<IIdentifiable>();
            string cmd;

            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs.Length == 2)
                {
                    string model = cmdArgs[0];
                    string id = cmdArgs[1];
                    IIdentifiable robot = new Robot(model, id);
                    list.Add(robot);
                }
                else if (cmdArgs.Length == 3)
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];
                    IIdentifiable citizen = new Citizen(name, age, id);
                    list.Add(citizen);
                }                
            }
            
            string digits = Console.ReadLine();

             foreach (IIdentifiable member in list)
             {
                 if (member.Id.EndsWith(digits))
                     Console.WriteLine(member.Id);
             }
            

        }
    }

