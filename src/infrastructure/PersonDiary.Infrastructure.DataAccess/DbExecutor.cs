using PersonDiary.Infrastucture.Domain.DataAccess;
using PersonDiary.Infrastucture.Domain.Models.DataAccess;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.DataAccess
{
    public abstract class DbExecutor:IDbExecutor
    {
        private readonly string connectionString;
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
                    queryObject.CommandType).ConfigureAwait(false);

                return result.AsList();
            }
        }
    }
}
