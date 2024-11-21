using Computools_Test_Task.Interfaces;
using Computools_Test_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Computools_Test_Task
{
    internal class StudentEditor : IStudentEditor
    {
        public List<Student> FillStudents()
        {
            return new List<Student>
            {
                new Student
                {
                    id = Guid.Parse("9D20B20A-AB66-43F0-81BA-D33732EB5FEB"),
                    firstName = "Jack",
                    secondName = "Armstrong",
                    age = 22,
                },
                new Student
                {
                    id = Guid.Parse("A3088A92-CE7F-44DE-BCAA-CBDF34CF8DD9"),
                    firstName = "Tom",
                    secondName = "Doe",
                    age = 23,
                }
            };
        }

        public void SetSubject(List<Student> students, List<Subject> subjects)
        {
            foreach (var student in students)
            {
                student.subjects = subjects.Where(s=>s.studentId == student.id).ToList();
            }
        }

        public double CalculateAverageGrade(Student student)
        {
            if (student.subjects.Count == 0)
            {
                throw new InvalidOperationException("Cannot calculate average grade for a student with no subjects.");
            }

            var tempSum = 0;
            foreach (var item in student.subjects)
            {
                tempSum = tempSum + item.grade;
            }

            double result = tempSum / (double)student.subjects.Count;
            return result;
        }

        public void SetGrant(Student student, double avgGrade)
        {
            if (avgGrade < 60)
            {
                student.grantType = GrantType.None;
            }
            else if (avgGrade >= 60 && avgGrade < 90)
            {
                student.grantType = GrantType.Regular;
            }
            else
            {
                student.grantType = GrantType.Increased;
            }
            
        }
    }
}
