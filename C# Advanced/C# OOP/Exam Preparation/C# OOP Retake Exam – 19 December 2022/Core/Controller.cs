using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Utilities.Messages;
using System.Collections.ObjectModel;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private readonly IRepository<ISubject> subjects;
        private readonly IRepository<IStudent> students;
        private readonly IRepository<IUniversity> universities;
        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }
        public string AddStudent(string firstName, string lastName)
        {
            IStudent student = students.FindByName($"{firstName} {lastName}");

            if (student != null)
            {

                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            student = new Student(students.Models.Count + 1, firstName, lastName);

            students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != nameof(TechnicalSubject) && subjectType != nameof(HumanitySubject) && subjectType != nameof(EconomicalSubject))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            ISubject subject = subjects.FindByName(subjectName);

            if(subject != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            if (subjectType == nameof(EconomicalSubject))
            {
                subject = new EconomicalSubject(subjects.Models.Count+1, subjectName);
            }
            else if (subjectType == nameof(HumanitySubject))
            {
                subject = new HumanitySubject(subjects.Models.Count+1, subjectName);
            }
            else
            {
                subject = new TechnicalSubject(subjects.Models.Count+1, subjectName);
            }
            //"{subjectType} {subjectName} is created and added to the {relevantRepositoryTypeName}!"

            subjects.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subject.GetType().Name, subjectName, subjects.GetType().Name);
        }
        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            IUniversity university = universities.FindByName(universityName);

            if (university != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity,universityName);
            }

            // conversion not sure working properly
            List<int> requiredSubjectsIds = new List<int>();

            foreach (string subjectName in requiredSubjects)
            {
                ISubject subject = subjects.FindByName(subjectName);

                requiredSubjectsIds.Add(subject.Id);
            }
                        
            university = new University(universities.Models.Count + 1, universityName, category, capacity, requiredSubjectsIds);  

            universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);
            
            if(student == null) 
            {
                return OutputMessages.InvalidStudentId;
            }

            if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;    
            }

            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.University, subject.Name);
        }


        public string ApplyToUniversity(string studentName, string universityName)
        {
            IStudent student = students.FindByName(studentName);
            
            string[] fullName = studentName.Split(" ");
            string firstname = fullName[0];
            string lastName = fullName[1];

            IUniversity university = universities.FindByName(universityName);

            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstname, lastName);
            }

            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, university.Name); 
            }

            

            if (university.RequiredSubjects.Except(student.CoveredExams).ToList().Any())
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            if (student.University != null)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, firstname, lastName, student.University.Name);
            }

            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, firstname, lastName, universityName);
        }


        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);

            int uniCount = 0;
            foreach (IStudent student in students.Models)
            {
                if(student.University == university)
                { 
                    uniCount++;
                }
            }
        
            StringBuilder sb = new StringBuilder();
            sb. 
                AppendLine($"*** {university.Name} ***")
               .AppendLine($"Profile: {university.Category}")
               .AppendLine($"Students admitted: {uniCount}") 
               .AppendLine($"University vacancy: {university.Capacity-uniCount}");

            return sb.ToString().TrimEnd();
        }
    }
}
