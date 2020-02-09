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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PersonDiary.GateWay.ApiClient;
using PersonDiary.Infractructure.Settings;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Cache;
using PersonDiary.Infrastructure.Cache.Redis;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.Cache;
using PersonDiary.Infrastructure.Domain.Consul;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Infrastructure.HttpApiClient.Helpers;
using PersonDiary.Infrastucture.Domain.DataAccess;

namespace PersonDiary.GateWay
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
                .AddSingleton<IPersonApiClient, PersonApiClient>();
            
            
            services.AddMvc(option=>option.EnableEndpointRouting=false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IConsulSettingsWatcher consulSettingsWatcher)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            consulSettingsWatcher.CheckSettingsAsync();
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
