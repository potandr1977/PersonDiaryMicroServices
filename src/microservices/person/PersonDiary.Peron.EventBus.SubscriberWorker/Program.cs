using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonDiary.Person.Domain.EventBus;
using PersonDiary.Person.EventBus;

namespace PersonDiary.Peron.EventBus.ConsumerWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IPersonSubscriberFactory,PersonSubscriberFactory>()
                .BuildServiceProvider();
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) => { services.AddHostedService<Worker>(); });
    }
}