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
        
         public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] classPublicFields = classType.GetFields((BindingFlags)28);

            MethodInfo[] classPublicMethods = classType.GetMethods((BindingFlags)20);

            MethodInfo[] classPrivateMethods = classType.GetMethods((BindingFlags)36);

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo fieldInfo in classPublicFields)
            {
                if (fieldInfo.Name.GetType().IsPublic)
                {
                    sb.AppendLine($"{fieldInfo.Name} must be private!");
                }
            }
            foreach (MethodInfo methodInfo in classPrivateMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{methodInfo.Name} have to be private!");
            }

            foreach (MethodInfo methodInfo in classPublicMethods.Where(m=>m.Name.StartsWith("set")))
            {
                 sb.AppendLine($"{methodInfo.Name} have to be public!");                   
            }
            
            return sb.ToString().TrimEnd();
         }

        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] fields = classType.GetFields((BindingFlags)60);

            object currInstance = Activator.CreateInstance(classType);

            StringBuilder sb = new StringBuilder();

            Console.WriteLine($"Class under investigation: {classType.FullName}");

            foreach (FieldInfo field in fields.Where(f=>requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(currInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
