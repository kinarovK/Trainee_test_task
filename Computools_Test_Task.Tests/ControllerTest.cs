using Computools_Test_Task.Interfaces;
using Computools_Test_Task.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computools_Test_Task.Tests
{
    public class ControllerTest
    {
        [Fact]
        public void Execute_ShouldCalculateAverageGradeAndSetGrantAndPrintStudent()
        {
            // Arrange
            var mockStudentEditor = new Mock<IStudentEditor>();
            var mockSubjectEditor = new Mock<ISubjectEditor>();
            var mockConsoleWriter = new Mock<IConsoleWriter>();

            // Mock data
            var students = new List<Student>
        {
            new Student { id = Guid.NewGuid(), firstName = "John", secondName = "Doe", subjects = new List<Subject>() },
            new Student { id = Guid.NewGuid(), firstName = "Jane", secondName = "Smith", subjects = new List<Subject>() }
        };

            var subjects = new List<Subject>
        {
            new Subject { id = Guid.NewGuid(), name = "Math", grade = 85, studentId = students[0].id },
            new Subject { id = Guid.NewGuid(), name = "English", grade = 90, studentId = students[1].id }
        };

            mockSubjectEditor.Setup(x => x.Fill()).Returns(subjects);
            mockStudentEditor.Setup(x => x.FillStudents()).Returns(students);
            mockStudentEditor.Setup(x => x.CalculateAverageGrade(It.IsAny<Student>())).Returns(88.0);

            var controller = new Controller(mockStudentEditor.Object, mockSubjectEditor.Object, mockConsoleWriter.Object);

            // Act
            controller.Execute();

            // Assert
            mockSubjectEditor.Verify(x => x.Fill(), Times.Once);
            mockStudentEditor.Verify(x => x.FillStudents(), Times.Once);
            mockStudentEditor.Verify(x => x.SetSubject(students, subjects), Times.Once);

            foreach (var student in students)
            {
                mockStudentEditor.Verify(x => x.CalculateAverageGrade(student), Times.Once);
                mockStudentEditor.Verify(x => x.SetGrant(student, 88.0), Times.Once);
            }

            mockConsoleWriter.Verify(x => x.PrintToConsole(It.IsAny<Student>()), Times.Once);
        }
    }
}
