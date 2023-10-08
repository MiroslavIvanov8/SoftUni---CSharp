using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
		private string firstName;
		private string lastName;
		private int age;
		private decimal salary;

		public decimal Salary
		{
			get 
			{
				return salary;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
				salary = value;
			}
		}


		public int Age
		{
			get
			{ 
				return age;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Age cannot be zero or a negative integer!");
				}
				age = value;
			}
		}


		public string LastName
		{
			get
			{ 
				return lastName;
			}
			set 
			{ 
				if (value != null && value.Length < 3)
				{
					throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
				}
				lastName = value;
			}
		}

		public string FirstName
		{
			get
			{ 
				return firstName;
			}
			set
			{ 
				if (value != null && value.Length < 3)
				{
					throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
				}
				firstName = value;
			}
		}



		public Person(string firstName, string lastName, int age, decimal salary)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
			Salary = salary;
		}
        
        public override string ToString() => $"{FirstName} {LastName} receives {Salary:f2} leva.";
		public void IncreaseSalary(decimal percentage)
		{
			if (Age >= 30)
			{
				Salary += Salary * percentage / 100;
			}
			else
			{				
				Salary += Salary * percentage / 200;
			}
        }

    }
}
