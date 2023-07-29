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
        public string GetAllMethods(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] classMethods = classType.GetMethods((BindingFlags)60);

            StringBuilder sb  = new StringBuilder();

            foreach(MethodInfo method in classMethods.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().FirstOrDefault().ParameterType}");
            }


            return sb.ToString().TrimEnd();
        }
        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] classPrivateMethods = classType.GetMethods((BindingFlags)36);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {className}");

            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo method in classPrivateMethods)
            { 
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
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

            foreach (MethodInfo methodInfo in classPublicMethods.Where(m=>m.Name.StartsWith("set")))
            {
                 sb.AppendLine($"{methodInfo.Name} have to be public!");                   
            }

            foreach (MethodInfo methodInfo in classPrivateMethods.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{methodInfo.Name} have to be private!");
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
