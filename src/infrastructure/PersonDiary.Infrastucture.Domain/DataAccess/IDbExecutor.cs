using PersonDiary.Infrastucture.Domain.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonDiary.Infrastucture.Domain.DataAccess
{
    public interface IDbExecutor
    {
        Task<List<T>> QueryAsync<T>(QueryObject queryObject, QuerySetting settings = null);

        Task ExecuteAsync(QueryObject queryObject);

        Task<TR> QueryFirstOrDefaultAsync<TR>(QueryObject queryObject);
    }
}
