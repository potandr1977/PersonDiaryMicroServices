using PersonDiary.Infrastructure.Domain.Cache;
using PersonDiary.Infrastucture.Domain.DataAccess;

namespace PersonDiary.Infrastructure.Cache
{
    public class CacheStore : ICacheStore
    {
        private readonly IDbExecutorRedis dbExecutorRedis;
        public CacheStore(IDbExecutorRedis dbExecutorRedis)
        {
            this.dbExecutorRedis = dbExecutorRedis;
        }

        public void SetValue(string key, string value)
        {
            dbExecutorRedis.SetValue(key,value);
        }

        public string GetValue(string key)
        {
            return dbExecutorRedis.GetValue(key);
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}