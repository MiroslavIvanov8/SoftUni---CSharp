﻿using SoftUni.Data;

namespace SoftUni.Models
{
    public  class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; } = null!;
        public int ManagerId { get; set; }

        public virtual Employee Manager { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
