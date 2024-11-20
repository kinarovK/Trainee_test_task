using Computools_Test_Task.Interfaces;
using Computools_Test_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computools_Test_Task
{
    internal class Controller : IController
    {
        private readonly IStudentEditor studentEditor;
        private readonly ISubjectEditor subjectEditor;
        private readonly IConsoleWriter consoleWriter;

        public Controller(IStudentEditor studentEditor, ISubjectEditor subjectEditor, IConsoleWriter consoleWriter) 
        {
            this.studentEditor = studentEditor;
            this.subjectEditor = subjectEditor;
            this.consoleWriter = consoleWriter;
        }

        public void Execute()
        {
            var subjects = this.subjectEditor.Fill();
            var students = this.studentEditor.FillStudents();
            studentEditor.SetSubject(students, subjects);

            foreach (var student in students)
            {
                student.averageGrade = this.studentEditor.CalculateAverageGrade(student);
                this.studentEditor.SetGrant(student, student.averageGrade);
            }
            var rand = new Random();
            var selectedStudent = students[rand.Next(0, students.Count-1)];
            this.consoleWriter.PrintToConsole(selectedStudent);
        }
    }
}
