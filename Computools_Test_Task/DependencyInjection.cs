using Computools_Test_Task.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computools_Test_Task
{
    [ExcludeFromCodeCoverage]
    internal static class DependencyInjection
    {
        public static void DependencyRegistration(this ServiceCollection services)
        {
            services.AddScoped<IController, Controller>();
            services.AddScoped<ISubjectEditor, SubjectEditor>();
            services.AddScoped<IStudentEditor, StudentEditor>();
            services.AddScoped<IConsoleWriter, ConsoleWriter>();
        }
    }
}
