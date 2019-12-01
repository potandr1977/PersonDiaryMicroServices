using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PersonDiary.Infrastucture.Domain.Models.Models
{
    public class QueryObject
    {
        public QueryObject(string sql, List<object> queryParams, CommandType commandType)
        {
            if (string.IsNullOrEmpty(sql)) throw new ArgumentNullException(nameof(sql));
            Sql = sql;
            QueryParams = queryParams;
            CommandType = commandType;
        }
        public string Sql { get; private set; }
        public List<object> QueryParams { get; private set; }
        public CommandType CommandType { get; private set; }
    }
}
