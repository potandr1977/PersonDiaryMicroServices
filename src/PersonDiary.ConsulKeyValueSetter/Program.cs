using System;

namespace PersonDiary.ConsulKeyValueSetter
{
    class Program
    {
        static void Main(string[] args)
        {
            ////setup our DI
            //var serviceProvider = new ServiceCollection()
            //    .AddLogging()
            //    .AddSingleton<IFooService, FooService>()
            //    .AddSingleton<IBarService, BarService>()
            //    .BuildServiceProvider();

            ////configure console logging
            //serviceProvider
            //    .GetService<ILoggerFactory>()
            //    .AddConsole(LogLevel.Debug);

            //var logger = serviceProvider.GetService<ILoggerFactory>()
            //    .CreateLogger<Program>();
            //logger.LogDebug("Starting application");

            ////do the actual work here
            //var bar = serviceProvider.GetService<IBarService>();

            Console.WriteLine("Hello World!");
        }
    }
}
