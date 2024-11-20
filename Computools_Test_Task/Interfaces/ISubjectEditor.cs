using Computools_Test_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computools_Test_Task.Interfaces
{
    public interface ISubjectEditor
    {
        public List<Subject> Fill();
        public List<Subject> GetSubjectStudentId(Guid studentId, List<Subject> subjects);
    }
}
