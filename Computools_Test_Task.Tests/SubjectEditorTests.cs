using Computools_Test_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computools_Test_Task.Tests
{
    public class SubjectEditorTests
    {
        private readonly List<Subject> testSubjects = new List<Subject>
        {
            new Subject
            {
                id = Guid.NewGuid(),
                name = "TestSubject1",
                grade = 85,
                date = DateTime.Now,
                studentId = Guid.Parse("9D20B20A-AB66-43F0-81BA-D33732EB5FEB"),
            },
            new Subject
            {
                id = Guid.NewGuid(),
                name = "TestSubject2",
                grade = 57,
                date = DateTime.Now.AddDays(-7),
                studentId = Guid.Parse("9D20B20A-AB66-43F0-81BA-D33732EB5FEB"),
            },
        };
        

        [Fact]
        public void FillShouldReturnTwoSubjects()
        {
            // Arrange
            var service = new SubjectEditor();

            // Act
            var subjects = service.Fill();

            // Assert
            Assert.Equal(4, subjects.Count);
        }

        [Fact]
        public void FillShouldContainExpectedStudentIds()
        {
            // Arrange
            var service = new SubjectEditor();
            var expectedStudentIds = new[]
            {
                Guid.Parse("9D20B20A-AB66-43F0-81BA-D33732EB5FEB"),
                Guid.Parse("A3088A92-CE7F-44DE-BCAA-CBDF34CF8DD9")
            };

            // Act
            var subjects = service.Fill();
            var actualStudentIds = subjects.Select(s => s.studentId).Distinct();

            // Assert
            Assert.All(expectedStudentIds, id => Assert.Contains(id, actualStudentIds));
        }

        [Fact]
        public void FillShouldContainValidGrades()
        {
            // Arrange
            var service = new SubjectEditor();

            // Act
            var subjects = service.Fill();

            // Assert
            Assert.All(subjects, s => Assert.InRange(s.grade, 0, 100));
        }

        [Fact]
        public void FillShouldAssignDifferentIdsToSubjects()
        {
            // Arrange
            var service = new SubjectEditor();

            // Act
            var subjects = service.Fill();

            // Assert
            Assert.Equal(subjects.Count, subjects.Select(s => s.id).Distinct().Count());
        }

        [Fact]
        public void GetSubjectStudentIdShouldReturnSubjectsForStudent()
        {
            // Arrange
            var service = new SubjectEditor();
            var studentId = Guid.Parse("9D20B20A-AB66-43F0-81BA-D33732EB5FEB");

            // Act
            var result = service.GetSubjectStudentId(studentId, testSubjects);

            // Assert
            Assert.NotEmpty(result);
            Assert.All(result, s => Assert.Equal(studentId, s.studentId));
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetSubjectStudentIdReturnsExceptionForUnkownId()
        {
            // Arrange
            var service = new SubjectEditor();
            var unknownStudentId = Guid.NewGuid();

            // Act
            var exception = Assert.Throws<ArgumentException>(() => service.GetSubjectStudentId(unknownStudentId, testSubjects));
            
            // Assert
            Assert.Equal("Student with selected Id not found", exception.Message);
        }
    }
}
