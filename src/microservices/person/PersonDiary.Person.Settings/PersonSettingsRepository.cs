using PersonDiary.Infractructure.Settings;
using PersonDiary.Infrastructure.Domain.Cache;

namespace PersonDiary.Person.Settings
{
    public class PersonSettingsRepository: SettingsRepository
    {
        public PersonSettingsRepository(ICacheStore cacheStore) : base(cacheStore)
        {
        }

        public override string Get(string name)
        {
            switch (name)
            {
                
            }

            return base.Get(name);
        }
    }
}
