using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Calc.Launcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) => {
                services.AddTransient<IInterpreter, Interpreter>();
                services.AddSingleton<ILogger, FileLogger>();
            })
            .Build()
            )
            {
                using (var serviceScope = host.Services.CreateScope())
                {
                    var calc = new ConsoleCalc(serviceScope.ServiceProvider.GetRequiredService<IInterpreter>());
                    calc.Run(args[0]);
                }
            }
        }
    }
}
