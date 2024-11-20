using Computools_Test_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computools_Test_Task.Tests
{
    public class StudentEditorTests
    {
        [Fact]
        public void FillStudentReturnsList()
        {
            //Arrange 
            var studentEditor = new StudentEditor();

            //Act
            var students = studentEditor.FillStudents();

            //Assert
            Assert.IsType<List<Student>>(students);
        }

        [Fact]
        public void FillStudentListIsNotEmpty()
        {
            //Arrange 
            var studentEditor = new StudentEditor();

            //Act
            var students = studentEditor.FillStudents();

            //Assert
            Assert.NotEmpty(students);
        }

        [Fact]
        public void SetSubjectChangeStudent()
        {
            //Arrange 
            var testGuid = Guid.NewGuid();
            var studentEditor = new StudentEditor();
            var students = new List<Student>();
            students.Add(new Student 
            {
                id = testGuid,
                firstName = "FirstName",
                secondName = "LastName",
                age = 22,
            });

            var subjects = new List<Subject>
            {
                new Subject
                {
                    id = Guid.NewGuid(),
                    date = DateTime.Now,
                    grade = 99,
                    name = "TestSubject1",
                    studentId = testGuid,
                },
                new Subject
                {
                    id = Guid.NewGuid(),
                    date = DateTime.Now.AddDays(-5),
                    grade = 55,
                    name = "TestSubject2",
                    studentId = testGuid,
                },
            };

            //Act
            studentEditor.SetSubject(students, subjects);
           
            //Assert
            Assert.NotEmpty(students.First().subjects);
            Assert.Equal(2, students.First().subjects.Count);
        }

        [Theory]
        [InlineData(50,50, 50)]
        [InlineData(1,99, 50)]
        [InlineData(34, 83, 58.5)]
        public void CalculateAverageGrade(byte firstGrade, byte secondGrade, double expectedAvg)
        {
            //Arrange 
            var testGuid = Guid.NewGuid();
            var subjects = new List<Subject>
            {
                new Subject
                {
                    id = Guid.NewGuid(),
                    date = DateTime.Now,
                    grade = firstGrade,
                    name = "TestSubject1",
                    studentId = testGuid,
                },
                new Subject
                {
                    id = Guid.NewGuid(),
                    date = DateTime.Now.AddDays(-5),
                    grade = secondGrade,
                    name = "TestSubject2",
                    studentId = testGuid,
                },
            }; 

            var studentEditor = new StudentEditor();
            var student = new Student
            {
                id = testGuid,
                firstName = "FirstName",
                secondName = "LastName",
                age = 22,
                subjects = subjects,
            };

            //Act
            student.averageGrade = studentEditor.CalculateAverageGrade(student);

            //Assert
            Assert.Equal(expectedAvg, student.averageGrade);
        }

        [Theory]
        [InlineData(50.9, GrantType.None)]
        [InlineData(60.1, GrantType.Regular)]
        [InlineData(80.5, GrantType.Regular)]
        [InlineData(91, GrantType.Increased)]
        internal void SetGrantTest(double avgGrade, GrantType grant)
        {
            //Arrange 
            var testGuid = Guid.NewGuid();
            var studentEditor = new StudentEditor();
            var student = new Student
            {
                id = testGuid,
                firstName = "FirstName",
                secondName = "LastName",
                age = 22,
                averageGrade = avgGrade,
            };

            //Act

            studentEditor.SetGrant(student, avgGrade);

            //Assert 
            Assert.Equal(grant, student.grantType);
        }

    }
}
