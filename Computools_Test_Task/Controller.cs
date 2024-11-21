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
            try
            {
                var subjects = this.subjectEditor.Fill();
                var students = this.studentEditor.FillStudents();

                if (subjects is null || students is null)
                {
                    throw new InvalidOperationException("Students or Subjects data is missing.");
                }
                this.studentEditor.SetSubject(students, subjects);

                foreach (var student in students)
                {
                    student.averageGrade = this.studentEditor.CalculateAverageGrade(student);
                    this.studentEditor.SetGrant(student, student.averageGrade);
                }
                var rand = new Random();
                var selectedStudent = students[rand.Next(students.Count)];
                this.consoleWriter.PrintToConsoleResult(selectedStudent);
            }
            catch (ArgumentNullException ex)
            {
                this.consoleWriter.PrintToConsoleErrorMessage($"{ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                this.consoleWriter.PrintToConsoleErrorMessage($"{ex.Message}");
            }
            catch (Exception ex)
            {
                this.consoleWriter.PrintToConsoleErrorMessage($"{ex.Message}");
            }
        }
    }
}
