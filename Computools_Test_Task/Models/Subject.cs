using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computools_Test_Task.Models
{
    [ExcludeFromCodeCoverage]
    public class Subject
    {
        public Guid id;
        public string name;
        public Guid studentId;
        public byte grade; 
        public DateTime date;
    }
}
