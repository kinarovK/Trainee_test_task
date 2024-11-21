using Computools_Test_Task.Interfaces;
using Computools_Test_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computools_Test_Task
{
    internal class SubjectEditor : ISubjectEditor
    {
        public List<Subject> Fill()
        {
            var subjects = new List<Subject>
            {
                new Subject
                {
                    id = Guid.NewGuid(),
                    name = "Math",
                    grade = 35,
                    date = DateTime.Now,
                    studentId = Guid.Parse("9D20B20A-AB66-43F0-81BA-D33732EB5FEB"),
                },
                new Subject
                {
                    id = Guid.NewGuid(),
                    name = "Geography",
                    grade = 57,
                    date = DateTime.Now.AddDays(-7),
                    studentId = Guid.Parse("9D20B20A-AB66-43F0-81BA-D33732EB5FEB"),
                },
                new Subject
                {
                    id = Guid.NewGuid(),
                    name = "Biology",
                    grade = 78,
                    date = DateTime.Now.AddDays(-8),
                    studentId = Guid.Parse("A3088A92-CE7F-44DE-BCAA-CBDF34CF8DD9"),
                },
                  new Subject
                {
                    id = Guid.NewGuid(),
                    name = "English",
                    grade = 99,
                    date = DateTime.Now.AddDays(-7),
                    studentId = Guid.Parse("A3088A92-CE7F-44DE-BCAA-CBDF34CF8DD9"),
                }
            };
            return subjects;
        }

        public List<Subject> GetSubjectStudentId(Guid studentId, List<Subject> subjects)
        {
            var result = new List<Subject>();
            result.AddRange(subjects.Where( s=> s.studentId == studentId).ToList());
            if (result.Count == 0)
            {
                throw new ArgumentException("Student with selected Id not found");
            }
            return result;
        }
    }
}
