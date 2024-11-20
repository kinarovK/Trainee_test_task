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
            name = "Math",
            grade = 85,
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
        

        [Fact]
        public void Fill_ShouldReturnFourSubjects()
        {
            // Arrange
            var service = new SubjectEditor();

            // Act
            var subjects = service.Fill();

            // Assert
            Assert.Equal(4, subjects.Count); // Ensure there are 4 subjects
        }

        [Fact]
        public void Fill_ShouldContainExpectedStudentIds()
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
        public void Fill_ShouldContainValidGrades()
        {
            // Arrange
            var service = new SubjectEditor();

            // Act
            var subjects = service.Fill();

            // Assert
            Assert.All(subjects, s => Assert.InRange(s.grade, 0, 100));
        }

        [Fact]
        public void Fill_ShouldAssignDifferentIdsToSubjects()
        {
            // Arrange
            var service = new SubjectEditor();

            // Act
            var subjects = service.Fill();

            // Assert
            Assert.Equal(subjects.Count, subjects.Select(s => s.id).Distinct().Count());
        }

        [Fact]
        public void GetSubjectStudentId_ShouldReturnSubjectsForStudent()
        {
            // Arrange
            var service = new SubjectEditor();
            var studentId = Guid.Parse("9D20B20A-AB66-43F0-81BA-D33732EB5FEB");

            // Act
            var result = service.GetSubjectStudentId(studentId, testSubjects);

            // Assert
            Assert.NotEmpty(result);
            Assert.All(result, s => Assert.Equal(studentId, s.studentId));
            Assert.Equal(2, result.Count); // There are 2 subjects for this studentId
        }

        [Fact]
        public void GetSubjectStudentId_ShouldReturnEmptyListForUnknownStudentId()
        {
            // Arrange
            var service = new SubjectEditor();
            var unknownStudentId = Guid.NewGuid();

            // Act
            var result = service.GetSubjectStudentId(unknownStudentId, testSubjects);

            // Assert
            Assert.Empty(result);
        }

    }
}
