using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> students;
        public StudentRepository()
        {
            students= new List<IStudent>();
        }
        public IReadOnlyCollection<IStudent> Models => students;

        public void AddModel(IStudent model)
        {
            students.Add(model);
        }

        public IStudent FindById(int id)=>students.FirstOrDefault(x=>x.Id==id);

        public IStudent FindByName(string name)
        {
            string[] fullName = name.Split(" ");

            string firstName = fullName[0];
            string lastName = fullName[1];

            IStudent student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            return student;
        }
    }
}
