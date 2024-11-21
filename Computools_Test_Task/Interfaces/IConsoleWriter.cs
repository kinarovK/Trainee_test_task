using Computools_Test_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computools_Test_Task.Interfaces
{
    public interface IConsoleWriter
    {
        public void PrintToConsoleResult(Student student);
        public void PrintToConsoleErrorMessage(string message);
    }
}
