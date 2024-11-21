using Computools_Test_Task.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Computools_Test_Task
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new ServiceCollection();

            service.DependencyRegistration();

            var controller = service.BuildServiceProvider().GetService<IController>();

            controller!.Execute();
        }
    }
}
