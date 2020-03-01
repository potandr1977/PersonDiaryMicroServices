using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.DataAccess;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Person.Domain.DataAccess.Executor;

namespace PersonDiary.Person.DataAccess.Executor
{
    public class LifeEventDbExecutor : DbExecutor, ILifeEventDbExecutor
    {
        public LifeEventDbExecutor(ISettingsRepository settingsRepository)
        {
            connectionString = settingsRepository.Get(SettingKeys.ConnectionStringLifeEvent);
        }
    }
}