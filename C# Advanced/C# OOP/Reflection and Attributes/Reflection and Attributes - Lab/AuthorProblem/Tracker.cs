using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProblem
{
    public class Tracker
    {
        public Tracker()
        {

        }
        void PrintMethodsByAuthor()
        {
            Type classType = typeof(StartUp);

            MethodInfo[] classMethods = classType.GetMethods((BindingFlags)60);

            foreach (MethodInfo method in classMethods)
            {
                AuthorAttribute[] attributes = method.GetCustomAttributes<AuthorAttribute>().ToArray();
                foreach (AuthorAttribute att in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {att.Name}");
                }    
            }
        }
    }
}
