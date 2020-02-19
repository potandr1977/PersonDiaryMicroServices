using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PersonDiary.Person.ApiClient;
using PersonDiary.Infractructure.Settings;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Infrastructure.HttpApiClient.Helpers;
using PersonDiary.Person.Domain.Business;

namespace PersonDiary.Test.Person.Business
{
    [TestFixture]
    public class PersonService
    {
        private IPersonService personService;
        [SetUp]
        public void Setup()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ISettingsRepository, SettingsRepository>()
                .AddSingleton<IHttpRequestExecutor, HttpRequestExecutor>()
                .AddSingleton<IUriCreator, UriCreator>()
                .AddSingleton<IResponseParser, ResponseParser>()
                .AddSingleton<IPersonApiClient, PersonApiClient>()
                .BuildServiceProvider();
           
            personService = serviceProvider.GetService<IPersonService>();
        }
    }
}