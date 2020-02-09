using System;
using PersonDiary.Infrastucture.Domain.DataAccess;
using StackExchange.Redis;

namespace PersonDiary.Infrastructure.Cache.Redis
{
    public class DbExecutorRedis : IDbExecutorRedis
    {
        
        private const string redisHost = "localhost";
        private readonly int redisPort = 6379;
        private ConnectionMultiplexer connectionMultiplexer;
        
        public DbExecutorRedis()
        {
            Connect();
        }
        
        public void Connect()
        {
            try
            {
                var configString = $"{redisHost}:{redisPort},connectRetry=5";
                connectionMultiplexer = ConnectionMultiplexer.Connect(configString);
            }
            catch (RedisConnectionException err)
            {
                throw err;
            }
        }
        
        public void SetValue(string key, string value)
        {
            var db = connectionMultiplexer.GetDatabase();
            db.StringSet(key, value);
        }

        public string GetValue(string key)
        {
            var db = connectionMultiplexer.GetDatabase();
            return  db.StringGet(key);
        }
    }
}