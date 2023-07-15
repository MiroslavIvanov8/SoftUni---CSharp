using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public Spy()
        {

        }

        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] fields = classType.GetFields((BindingFlags)60);

            object currInstance = Activator.CreateInstance(classType);

            StringBuilder sb = new StringBuilder();

            Console.WriteLine($"Class under investigation: {classType.Name}");

            foreach (FieldInfo field in fields.Where(f=>requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(currInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
