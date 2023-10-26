using System.Text;
using SoftUni;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var contex = new SoftUniContext();
            Console.WriteLine(GetEmployeesFullInformation(contex));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Select(e=> new {e.EmployeeId, e.FirstName,e.MiddleName,e.LastName,departmentName = e.Department.Name, e.Salary})
                .OrderBy(e=>e.EmployeeId)
                .ToList();

            foreach (var e in employees)
            {
                string[] names = new string[3]{e.FirstName,e.MiddleName, e.FirstName};
                sb.AppendLine($"{string.Join(" ",names)} from {e.departmentName} - ${e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}