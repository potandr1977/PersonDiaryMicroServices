namespace PersonDiary.Infrastucture.Domain.DataAccess
{
    public interface IDbExecutorRedis
    {
        void SetValue(string key, string value);
        string GetValue(string key);
    }
}