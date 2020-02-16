using PersonDiary.Infrastructure.DataAccess;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastucture.Domain.DataAccess;
using PersonDiary.Person.Domain.DataAccess.Executor;

namespace PersonDiary.Person.DataAccess.Executor
{
    public class PersonDbExecutor : DbExecutor, IPersonDbExecutor
    {
        public PersonDbExecutor(ISettingsRepository settingsRepository) : base(settingsRepository)
        {
        }
    }
}