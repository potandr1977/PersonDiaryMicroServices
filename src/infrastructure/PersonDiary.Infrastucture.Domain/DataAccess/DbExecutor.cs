using PersonDiary.Infrastucture.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Infrastucture.Domain.DataAccess
{
    public interface DbExecutor
    {
        Task<List<T>> QueryAsync<T>(QueryObject queryObject, QuerySetting settings = null);
    }
}
