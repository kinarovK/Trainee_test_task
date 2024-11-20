using Computools_Test_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computools_Test_Task.Interfaces
{
    public interface IStudentEditor
    {
        public List<Student> FillStudents();
        public void SetSubject(List<Student> students, List<Subject> subjects);
        public double CalculateAverageGrade(Student student);
        public void SetGrant(Student student, double avgGrade);
    }
}
