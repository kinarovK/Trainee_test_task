using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computools_Test_Task.Models
{
    [ExcludeFromCodeCoverage]
    public class Student
    {
        public Guid id;
        public string firstName;
        public string secondName;
        public int age;
        public List<Subject> subjects;
        public double averageGrade;
        public GrantType grantType;

    }
}
