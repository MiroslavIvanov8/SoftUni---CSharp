﻿using System.Globalization;
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
            Console.WriteLine(GetAddressesByTown(contex));

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

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            /*
             var employeesWithProject = context.Employees
                .Where(e => e.EmployeesProjects
                    .Any(ep => ep.Project.StartDate.Year >= 2001 &&
                               ep.Project.StartDate.Year <= 2003))  // first we filter only the employees with projects in the given date
                .Take(10)
                .Select(e => new  // then we select needed data of these filtered employees
                {
                    e.FirstName,
                    e.LastName,
                    managerFirstName = e.Manager!.FirstName,  // notice ! operator skipping null objects
                    managerLastName = e.Manager!.LastName,
                    projects = e.EmployeesProjects
                        .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                     ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                    {
                        projectName = ep.Project.Name, // and a clever way to use ternary operator in the linq querry
                        startDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        endDate = ep.Project.EndDate.HasValue ?
                            ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"

                    })
                }).ToList();  // like that we do all the necessary operations within the linq query, perfect example
            */

            var employeesData = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Manager,
                    projects = e.EmployeesProjects.Select(ep=> new
                    {
                        startDate = ep.Project.StartDate,
                        endDate = ep.Project.EndDate,
                        name = ep.Project.Name
                    })
                }).ToList();

            
            StringBuilder sb = new StringBuilder();
            foreach (var e in employeesData.Where(e => e.Manager != null))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.Manager.FirstName} {e.Manager.LastName}");
                
                foreach (var project in e.projects)
                {
                    if (project.startDate.Year >= 2001 & project.startDate.Year <= 2003)
                    {
                        string endDate = project.endDate is null ? "not finished" : project.endDate.ToString();

                        sb.AppendLine($"--{project.name} - {project.startDate} - {endDate}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var adressesData = context.Addresses
                .Select(a => new
                {
                    countOfEmployees = a.Employees.Count,
                    townName = a.Town.Name,
                    a.AddressText
                })
                .OrderByDescending(a=> a.countOfEmployees)
                .ThenBy(a=>a.townName)
                .ThenBy(a=>a.AddressText)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var a in adressesData)
            {
                sb.AppendLine($"{a.AddressText}, {a.townName} - {a.countOfEmployees} employees");
            }

            return sb.ToString().TrimEnd();
        }
    }
}