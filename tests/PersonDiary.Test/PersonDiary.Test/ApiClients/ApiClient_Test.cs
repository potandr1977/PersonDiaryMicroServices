using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PersonDiary.Person.ApiClient;
using PersonDiary.Infractructure.Settings;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.Consul;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Infrastructure.HttpApiClient.Helpers;
using PersonDiary.Person.Dto;

namespace PersonDiary.Test.ApiClients
{
    [TestFixture]
    public class ApiClient_Test
    {
        private IPersonApiClient personApiClient;
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
           
            personApiClient = serviceProvider.GetService<IPersonApiClient>();
        }
        [Test]
        public async Task GetConsulValue()
        {
            await personApiClient.CreatePersonAsync(new UpdatePersonRequestDto
            {
                Person = new PersonDiary.Person.Dto.Person
                {
                    Id = 0,
                    Name = "Name1",
                    Surname= "Surname1", 
                    HasFile = true  
                }
            });
            Assert.Pass();
        }
    }
}