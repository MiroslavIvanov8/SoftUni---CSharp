using System.Linq.Expressions;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var contex = new SoftUniContext();
            //Console.WriteLine(GetEmployeesFullInformation(contex));
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(contex));
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(contex));
            Console.WriteLine(AddNewAddressToEmployee(contex));

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

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    departmentName = e.Department.Name,
                    e.Salary
                }).ToList();

            StringBuilder sb = new();
            foreach (var e in employees
                         .OrderBy(e=>e.Salary)
                         .ThenByDescending(e=>e.FirstName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.departmentName} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee employee = context.Employees
                .FirstOrDefault(e => e.LastName.StartsWith("Nakov"));

            employee.Address = address;

            context.SaveChanges();

            var employees = context.Employees
                .Select(e => new
                {
                    e.AddressId,
                    adressText = e.Address.AddressText
                })
                .OrderByDescending(e => e.AddressId);

            StringBuilder sb = new();
            foreach (var e in employees.Take(10))
            {
                sb.AppendLine($"{e.adressText}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}