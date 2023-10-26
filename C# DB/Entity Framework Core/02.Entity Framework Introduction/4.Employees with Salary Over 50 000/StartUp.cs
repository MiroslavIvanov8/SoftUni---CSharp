using System.Linq.Expressions;
using System.Text;
using SoftUni.Data;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var contex = new SoftUniContext();
            //Console.WriteLine(GetEmployeesFullInformation(contex));
            Console.WriteLine(GetEmployeesWithSalaryOver50000(contex));

        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                }).ToList();

            StringBuilder sb = new();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e=>e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e=>e.FirstName)
                .ToList();

            string result = string.Join(Environment.NewLine, employees
                .Select(e => $"{e.FirstName} - {e.Salary:f2}"));

            return result.TrimEnd();
        }
    }
}