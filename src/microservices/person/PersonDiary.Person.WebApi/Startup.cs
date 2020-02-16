using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PersonDiary.Infractructure.Settings;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Cache;
using PersonDiary.Infrastructure.Cache.Redis;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.DataAccess;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.Cache;
using PersonDiary.Infrastructure.Domain.Consul;
using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.EventBus.RabbitMq;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Infrastructure.HttpApiClient.Helpers;
using PersonDiary.Infrastucture.Domain.DataAccess;
using PersonDiary.Person.Business.Services;
using PersonDiary.Person.DataAccess;
using PersonDiary.Person.DataAccess.Dao;
using PersonDiary.Person.DataAccess.Executor;
using PersonDiary.Person.Domain.Business;
using PersonDiary.Person.Domain.DataAccess;
using PersonDiary.Person.Domain.DataAccess.Executor;
using PersonDiary.Person.EventBus;

namespace PersonDiary.Person.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IHttpRequestExecutor, HttpRequestExecutor>()
                .AddSingleton<IUriCreator, UriCreator>()
                .AddSingleton<IResponseParser, ResponseParser>()
                .AddSingleton<IConsulApiClient, ConsulApiClient>()
                .AddSingleton<IConsulSettingsWatcher, ConsulSettingsWatcher>()
                .AddSingleton<IDbExecutorRedis, DbExecutorRedis>()
                .AddSingleton<ICacheStore, CacheStore>()
                .AddSingleton<ISettingsRepository, SettingsRepository>()
                .AddSingleton<IPersonDbExecutor, PersonDbExecutor>()
                .AddSingleton<IPersonDao, PersonDao>()
                .AddSingleton<IPersonService, PersonService>()
                .AddSingleton<IPublisherFactory,PersonPublisherFactory>();
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env, 
            IConsulSettingsWatcher consulSettingsWatcher, 
            IDbExecutorRedis dbExecutorRedis)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            consulSettingsWatcher.CheckSettingsAsync();
            var personConnectionString = dbExecutorRedis.GetValue(SettingKeys.ConnectionStringPerson);
            
            dbExecutorRedis.SetValue(SettingKeys.ConnectionString, personConnectionString);
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
