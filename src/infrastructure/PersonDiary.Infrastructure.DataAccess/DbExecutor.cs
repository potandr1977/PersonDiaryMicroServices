using PersonDiary.Infrastucture.Domain.DataAccess;
using PersonDiary.Infrastucture.Domain.Models.DataAccess;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.Settings;

namespace PersonDiary.Infrastructure.DataAccess
{
    public abstract class DbExecutor : IDbExecutor
    {
        private readonly string connectionString;

        public DbExecutor(ISettingsRepository settingsRepository)
        {
            this.connectionString = settingsRepository.Get(SettingKeys.ConnectionString);
        }
        public async Task<List<T>> QueryAsync<T>(QueryObject queryObject, QuerySetting settings = null)
        {
            using (var cnn = new SqlConnection(connectionString))
            {
                await cnn.OpenAsync().ConfigureAwait(false);
                var result = await cnn.QueryAsync<T>(
                    queryObject.Sql,
                    queryObject.QueryParams,
                    null,
                    null,
                    queryObject.CommandType);

                return result.AsList();
            }
        }

        public async Task ExecuteAsync(QueryObject queryObject)
        {
            using (var cnn = new SqlConnection(connectionString))
            {
                await cnn.OpenAsync().ConfigureAwait(false);

                await cnn.ExecuteAsync(
                    queryObject.Sql,
                    queryObject.QueryParams,
                    null,
                    null,
                    queryObject.CommandType);

            }
        }
        public async Task<TR> QueryFirstOrDefaultAsync<TR>(QueryObject queryObject)
        {
            using (var cnn = new SqlConnection(this.connectionString))
            {
                await cnn.OpenAsync().ConfigureAwait(false);

                var result = await cnn.QueryFirstOrDefaultAsync<TR>(
                    queryObject.Sql,
                    queryObject.QueryParams,
                    null,
                    null,
                    queryObject.CommandType).ConfigureAwait(false);

                return result;
            }
        }
    }
}
