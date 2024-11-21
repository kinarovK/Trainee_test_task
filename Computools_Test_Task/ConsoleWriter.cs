using Computools_Test_Task.Interfaces;
using Computools_Test_Task.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computools_Test_Task
{
    [ExcludeFromCodeCoverage]
    internal class ConsoleWriter : IConsoleWriter
    {
        public void PrintToConsoleResult(Student student)
        {
            Console.WriteLine($"ID: {student.id}");
            Console.WriteLine($"Name: {student.firstName} {student.secondName}");
            Console.WriteLine($"Age: {student.age}");
            Console.WriteLine($"Average Grade: {student.averageGrade:F2}");
            Console.WriteLine($"Grant Type: {student.grantType}");
            Console.WriteLine("Subjects:");

            foreach (var subject in student.subjects)
            {
                Console.WriteLine($" - {subject.name}: {subject.grade}");
            }
        }

        public void PrintToConsoleErrorMessage(string message)
        {
            Console.WriteLine($"Error durring the app running: '\n' {message}");
        }
    }
}
